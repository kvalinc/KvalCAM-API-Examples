/* 
 * KvalCAM API
 *
 * KvalCAM interactive API documentation  Additional documentation is available here: https://docs.kvalinc.com/display/CAM/API  Examples are available on github here: https://github.com/kvalinc/KvalCAMAPIExamples
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IMachinesApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Sends a command to a particular machine
        /// </summary>
        /// <remarks>
        /// An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns></returns>
        void RestApiV1MachinesCommandsPost (MachinesCommandParameters command = null);

        /// <summary>
        /// Sends a command to a particular machine
        /// </summary>
        /// <remarks>
        /// An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RestApiV1MachinesCommandsPostWithHttpInfo (MachinesCommandParameters command = null);
        /// <summary>
        /// Gets all the summary information for machines in the line
        /// </summary>
        /// <remarks>
        /// This request is useful for determining the unique machine names in the line to send command requests to
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesInfoSummary</returns>
        MachinesInfoSummary RestApiV1MachinesGet ();

        /// <summary>
        /// Gets all the summary information for machines in the line
        /// </summary>
        /// <remarks>
        /// This request is useful for determining the unique machine names in the line to send command requests to
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesInfoSummary</returns>
        ApiResponse<MachinesInfoSummary> RestApiV1MachinesGetWithHttpInfo ();
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Sends a command to a particular machine
        /// </summary>
        /// <remarks>
        /// An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RestApiV1MachinesCommandsPostAsync (MachinesCommandParameters command = null);

        /// <summary>
        /// Sends a command to a particular machine
        /// </summary>
        /// <remarks>
        /// An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1MachinesCommandsPostAsyncWithHttpInfo (MachinesCommandParameters command = null);
        /// <summary>
        /// Gets all the summary information for machines in the line
        /// </summary>
        /// <remarks>
        /// This request is useful for determining the unique machine names in the line to send command requests to
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesInfoSummary</returns>
        System.Threading.Tasks.Task<MachinesInfoSummary> RestApiV1MachinesGetAsync ();

        /// <summary>
        /// Gets all the summary information for machines in the line
        /// </summary>
        /// <remarks>
        /// This request is useful for determining the unique machine names in the line to send command requests to
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesInfoSummary)</returns>
        System.Threading.Tasks.Task<ApiResponse<MachinesInfoSummary>> RestApiV1MachinesGetAsyncWithHttpInfo ();
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class MachinesApi : IMachinesApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MachinesApi"/> class.
        /// </summary>
        /// <returns></returns>
        public MachinesApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachinesApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public MachinesApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public IO.Swagger.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Sends a command to a particular machine An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns></returns>
        public void RestApiV1MachinesCommandsPost (MachinesCommandParameters command = null)
        {
             RestApiV1MachinesCommandsPostWithHttpInfo(command);
        }

        /// <summary>
        /// Sends a command to a particular machine An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RestApiV1MachinesCommandsPostWithHttpInfo (MachinesCommandParameters command = null)
        {

            var localVarPath = "/machines/commands";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (command != null && command.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(command); // http body (model) parameter
            }
            else
            {
                localVarPostBody = command; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1MachinesCommandsPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Sends a command to a particular machine An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RestApiV1MachinesCommandsPostAsync (MachinesCommandParameters command = null)
        {
             await RestApiV1MachinesCommandsPostAsyncWithHttpInfo(command);

        }

        /// <summary>
        /// Sends a command to a particular machine An ErrorBase will be returned if the command is not recognized by the machine, see https://docs.kvalinc.com/display/CAM/Machine+Specific+Commands for all commands available, use GET /machines to get a list of unique machine names
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="command"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1MachinesCommandsPostAsyncWithHttpInfo (MachinesCommandParameters command = null)
        {

            var localVarPath = "/machines/commands";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (command != null && command.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(command); // http body (model) parameter
            }
            else
            {
                localVarPostBody = command; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1MachinesCommandsPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Gets all the summary information for machines in the line This request is useful for determining the unique machine names in the line to send command requests to
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>MachinesInfoSummary</returns>
        public MachinesInfoSummary RestApiV1MachinesGet ()
        {
             ApiResponse<MachinesInfoSummary> localVarResponse = RestApiV1MachinesGetWithHttpInfo();
             return localVarResponse.Data;
        }

        /// <summary>
        /// Gets all the summary information for machines in the line This request is useful for determining the unique machine names in the line to send command requests to
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of MachinesInfoSummary</returns>
        public ApiResponse< MachinesInfoSummary > RestApiV1MachinesGetWithHttpInfo ()
        {

            var localVarPath = "/machines";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);



            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1MachinesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesInfoSummary>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MachinesInfoSummary) Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesInfoSummary)));
        }

        /// <summary>
        /// Gets all the summary information for machines in the line This request is useful for determining the unique machine names in the line to send command requests to
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of MachinesInfoSummary</returns>
        public async System.Threading.Tasks.Task<MachinesInfoSummary> RestApiV1MachinesGetAsync ()
        {
             ApiResponse<MachinesInfoSummary> localVarResponse = await RestApiV1MachinesGetAsyncWithHttpInfo();
             return localVarResponse.Data;

        }

        /// <summary>
        /// Gets all the summary information for machines in the line This request is useful for determining the unique machine names in the line to send command requests to
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Task of ApiResponse (MachinesInfoSummary)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<MachinesInfoSummary>> RestApiV1MachinesGetAsyncWithHttpInfo ()
        {

            var localVarPath = "/machines";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);



            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1MachinesGet", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<MachinesInfoSummary>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (MachinesInfoSummary) Configuration.ApiClient.Deserialize(localVarResponse, typeof(MachinesInfoSummary)));
        }

    }
}
