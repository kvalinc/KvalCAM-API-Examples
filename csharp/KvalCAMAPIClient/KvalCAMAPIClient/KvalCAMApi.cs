using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KvalCAMAPIClient
{
    [Serializable]
    public class ApiRequestFailedException : Exception
    {
        public ApiRequestFailedException() { }
        public ApiRequestFailedException(string message) : base(message) { }
        public ApiRequestFailedException(string message, Exception inner) : base(message, inner) { }
        protected ApiRequestFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Example class that makes KvalCAM api HTTP requests, throws exceptions if anything fails
    /// </summary>
    public class KvalCAMApi
    {
        private readonly string _baseAddress;
        private readonly TimeSpan _requestTimeout;
        public KvalCAMApi(string baseAddress, TimeSpan? requestTimeout = null)
        {
            _baseAddress = baseAddress.EndsWith("/") ? baseAddress : baseAddress + "/";
            _requestTimeout = requestTimeout ?? TimeSpan.FromSeconds(5);
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_baseAddress),
                Timeout = _requestTimeout
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task<JObject> GetRequest(string requestUri, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            using (var httpClient = CreateHttpClient())
            {
                var response = await httpClient.GetAsync(requestUri);
                if (response.StatusCode != expectedStatusCode)
                {
                    FailWithUnexpectedStatusCode(expectedStatusCode, response.StatusCode);
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return string.IsNullOrWhiteSpace(responseContent) ? null : JObject.Parse(responseContent);
            }
        }

        private async Task<JObject> PostRequest(string requestUri, JObject jsonContent, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var requestContent = new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json");
            using (var httpClient = CreateHttpClient())
            {
                var response = await httpClient.PostAsync(requestUri, requestContent);
                if (response.StatusCode != expectedStatusCode)
                {
                    FailWithUnexpectedStatusCode(expectedStatusCode, response.StatusCode);
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return string.IsNullOrWhiteSpace(responseContent) ? null : JObject.Parse(responseContent);
            }
        }

        private async Task<JObject> PutRequest(string requestUri, JObject jsonContent, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var requestContent = new StringContent(jsonContent.ToString(), Encoding.UTF8, "application/json");
            using (var httpClient = CreateHttpClient())
            {
                var response = await httpClient.PutAsync(requestUri, requestContent);
                if (response.StatusCode != expectedStatusCode)
                {
                    var test = await response.Content.ReadAsStringAsync();
                    FailWithUnexpectedStatusCode(expectedStatusCode, response.StatusCode);
                }
                var responseContent = await response.Content.ReadAsStringAsync();
                return string.IsNullOrWhiteSpace(responseContent) ? null : JObject.Parse(responseContent);
            }
        }

        void FailWithUnexpectedStatusCode(HttpStatusCode expected, HttpStatusCode actual)
        {
            throw new ApiRequestFailedException($"Response returned with status code: {Convert.ToInt32(actual)}, expected status code: {Convert.ToInt32(expected)}, check that the KvalCAM host address in config is correct");
        }

        /// <summary>
        /// Invokes the host/pinge method, returns the KvalCAM version as a string
        /// </summary>
        public async Task<string> HostPing()
        {
            var response =  await GetRequest("host/ping");

            return response["KvalCAMVersion"].ToString();
        }

        /// <summary>
        /// Invokes the doorjobs/search method, returns the first doorjob that matches the name given, or null if no job is found
        /// </summary>
        public async Task<JObject> GetDoorJobByName(string name)
        {
            var jsonReqBody = new JObject
            {
                ["Name"] = name
            };

            var response = await PostRequest("doorjobs/search", jsonReqBody);
            var resultsArray = (JArray)response["Results"];

            if (!(resultsArray.FirstOrDefault() is JObject result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Invokes the featuregroups/search method, returns the first feature group that matches the name given, or null if no feature group is found
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<JObject> GetFeatureGroupByName(string name)
        {
            var jsonReqBody = new JObject
            {
                ["Name"] = name
            };

            var response = await PostRequest("featuregroups/search", jsonReqBody);
            var resultsArray = (JArray)response["Results"];
            if (!(resultsArray.FirstOrDefault() is JObject result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Invokes the editor/doorjobs/upload method, putting the doorjob data given into the editor
        /// </summary>
        public async Task UploadDoorJobToEditor(JObject doorJob)
        {
            var content = new JObject
            {
                ["DoorJob"] = doorJob
            };
            await PutRequest("editor/doorjob/upload", content);
        }

        /// <summary>
        /// Invokes the jobqueue/upload method, adding the doorjob to the kvalcam queue
        /// </summary>
        public async Task UploadDoorJobToQueue(JObject doorJob)
        {
            var content = new JObject
            {
                ["DoorJob"] = doorJob
            };

            var requestContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            using (var httpClient = CreateHttpClient())
            {
                var response = await httpClient.PostAsync("jobqueue/upload", requestContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var responseObj = JObject.Parse(responseContent);
                    // Check if it's not just a generic schema error (error caused by evaluation/validation)
                    if (responseObj.ContainsKey("Error"))
                    {
                        throw new ApiRequestFailedException("Job failed to evaluate or validate for the machine line and could not be added to queue");
                    }
                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApiRequestFailedException($"Response returned with unexpected status code: {Convert.ToInt32(response.StatusCode)}");
                }
            }
        }
    }
}
