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
    public interface IJobQueueApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns></returns>
        void RestApiV1JobqueuePost (AddJobToQueueParameters parameters = null);

        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RestApiV1JobqueuePostWithHttpInfo (AddJobToQueueParameters parameters = null);
        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue
        /// </summary>
        /// <remarks>
        /// Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns></returns>
        void RestApiV1JobqueueUploadPost (UploadJobToQueueParameters parameters = null);

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue
        /// </summary>
        /// <remarks>
        /// Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> RestApiV1JobqueueUploadPostWithHttpInfo (UploadJobToQueueParameters parameters = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RestApiV1JobqueuePostAsync (AddJobToQueueParameters parameters = null);

        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1JobqueuePostAsyncWithHttpInfo (AddJobToQueueParameters parameters = null);
        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue
        /// </summary>
        /// <remarks>
        /// Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task RestApiV1JobqueueUploadPostAsync (UploadJobToQueueParameters parameters = null);

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue
        /// </summary>
        /// <remarks>
        /// Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </remarks>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1JobqueueUploadPostAsyncWithHttpInfo (UploadJobToQueueParameters parameters = null);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class JobQueueApi : IJobQueueApi
    {
        private IO.Swagger.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobQueueApi"/> class.
        /// </summary>
        /// <returns></returns>
        public JobQueueApi(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = IO.Swagger.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobQueueApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public JobQueueApi(Configuration configuration = null)
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
        /// Adds an existing door job from the door job library to the KvalCAM job queue 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns></returns>
        public void RestApiV1JobqueuePost (AddJobToQueueParameters parameters = null)
        {
             RestApiV1JobqueuePostWithHttpInfo(parameters);
        }

        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RestApiV1JobqueuePostWithHttpInfo (AddJobToQueueParameters parameters = null)
        {

            var localVarPath = "/jobqueue";
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

            if (parameters != null && parameters.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(parameters); // http body (model) parameter
            }
            else
            {
                localVarPostBody = parameters; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1JobqueuePost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RestApiV1JobqueuePostAsync (AddJobToQueueParameters parameters = null)
        {
             await RestApiV1JobqueuePostAsyncWithHttpInfo(parameters);

        }

        /// <summary>
        /// Adds an existing door job from the door job library to the KvalCAM job queue 
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1JobqueuePostAsyncWithHttpInfo (AddJobToQueueParameters parameters = null)
        {

            var localVarPath = "/jobqueue";
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

            if (parameters != null && parameters.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(parameters); // http body (model) parameter
            }
            else
            {
                localVarPostBody = parameters; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1JobqueuePost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns></returns>
        public void RestApiV1JobqueueUploadPost (UploadJobToQueueParameters parameters = null)
        {
             RestApiV1JobqueueUploadPostWithHttpInfo(parameters);
        }

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> RestApiV1JobqueueUploadPostWithHttpInfo (UploadJobToQueueParameters parameters = null)
        {

            var localVarPath = "/jobqueue/upload";
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

            if (parameters != null && parameters.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(parameters); // http body (model) parameter
            }
            else
            {
                localVarPostBody = parameters; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1JobqueueUploadPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task RestApiV1JobqueueUploadPostAsync (UploadJobToQueueParameters parameters = null)
        {
             await RestApiV1JobqueueUploadPostAsyncWithHttpInfo(parameters);

        }

        /// <summary>
        /// Uploads a new job directly to the KvalCAM queue Door job id given is ignored, use PUT /editor/doorjob to load an existing job from library
        /// </summary>
        /// <exception cref="IO.Swagger.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="parameters"> (optional)</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> RestApiV1JobqueueUploadPostAsyncWithHttpInfo (UploadJobToQueueParameters parameters = null)
        {

            var localVarPath = "/jobqueue/upload";
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

            if (parameters != null && parameters.GetType() != typeof(byte[]))
            {
                localVarPostBody = Configuration.ApiClient.Serialize(parameters); // http body (model) parameter
            }
            else
            {
                localVarPostBody = parameters; // byte array
            }


            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("RestApiV1JobqueueUploadPost", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Object>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }

    }
}
