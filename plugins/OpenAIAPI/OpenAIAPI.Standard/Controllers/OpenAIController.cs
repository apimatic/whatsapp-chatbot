// <copyright file="OpenAIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>

namespace OpenAIAPI.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using Standard;
    using Authentication;
    using Http.Client;
    using Http.Request;
    using Http.Request.Configuration;
    using Http.Response;
    using Utilities;

    /// <summary>
    /// OpenAIController.
    /// </summary>
    public class OpenAIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAIController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal OpenAIController(IConfiguration config, IHttpClient httpClient,
            IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Lists the currently available (non-finetuned) models, and provides basic information about each one such as the owner and availability.
        /// </summary>
        /// <returns>Returns the Models.ListEnginesResponse response from the API call.</returns>
        [Obsolete]
        public Models.ListEnginesResponse ListEngines()
        {
            var t = ListEnginesAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists the currently available (non-finetuned) models, and provides basic information about each one such as the owner and availability.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEnginesResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.ListEnginesResponse> ListEnginesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/engines");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListEnginesResponse>(response.Body);
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about it such as the owner and availability.
        /// </summary>
        /// <param name="engineId">Required parameter: The ID of the engine to use for this request.</param>
        /// <returns>Returns the Models.Engine response from the API call.</returns>
        [Obsolete]
        public Models.Engine RetrieveEngine(
            string engineId)
        {
            var t = RetrieveEngineAsync(engineId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about it such as the owner and availability.
        /// </summary>
        /// <param name="engineId">Required parameter: The ID of the engine to use for this request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Engine response from the API call.</returns>
        [Obsolete]
        public async Task<Models.Engine> RetrieveEngineAsync(
            string engineId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/engines/{engine_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "engine_id", engineId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Engine>(response.Body);
        }

        /// <summary>
        /// Creates a completion for the provided prompt and parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateCompletionResponse response from the API call.</returns>
        public Models.CreateCompletionResponse CreateCompletion(
            Models.CreateCompletionRequest body)
        {
            var t = CreateCompletionAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a completion for the provided prompt and parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateCompletionResponse response from the API call.</returns>
        public async Task<Models.CreateCompletionResponse> CreateCompletionAsync(
            Models.CreateCompletionRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/completions");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateCompletionResponse>(response.Body);
        }

        /// <summary>
        /// Creates a new edit for the provided input, instruction, and parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateEditResponse response from the API call.</returns>
        public Models.CreateEditResponse CreateEdit(
            Models.CreateEditRequest body)
        {
            var t = CreateEditAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a new edit for the provided input, instruction, and parameters.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateEditResponse response from the API call.</returns>
        public async Task<Models.CreateEditResponse> CreateEditAsync(
            Models.CreateEditRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/edits");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateEditResponse>(response.Body);
        }

        /// <summary>
        /// Creates an embedding vector representing the input text.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateEmbeddingResponse response from the API call.</returns>
        public Models.CreateEmbeddingResponse CreateEmbedding(
            Models.CreateEmbeddingRequest body)
        {
            var t = CreateEmbeddingAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates an embedding vector representing the input text.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateEmbeddingResponse response from the API call.</returns>
        public async Task<Models.CreateEmbeddingResponse> CreateEmbeddingAsync(
            Models.CreateEmbeddingRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/embeddings");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateEmbeddingResponse>(response.Body);
        }

        /// <summary>
        /// The search endpoint computes similarity scores between provided query and documents. Documents can be passed directly to the API if there are no more than 200 of them.
        /// To go beyond the 200 document limit, documents can be processed offline and then used for efficient retrieval at query time. When `file` is set, the search endpoint searches over all the documents in the given file and returns up to the `max_rerank` number of documents. These documents will be returned along with their search scores.
        /// The similarity score is a positive score that usually ranges from 0 to 300 (but can sometimes go higher), where a score above 200 usually means the document is semantically similar to the query.
        /// </summary>
        /// <param name="engineId">Required parameter: The ID of the engine to use for this request.  You can select one of `ada`, `babbage`, `curie`, or `davinci`..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateSearchResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateSearchResponse CreateSearch(
            string engineId,
            Models.CreateSearchRequest body)
        {
            var t = CreateSearchAsync(engineId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// The search endpoint computes similarity scores between provided query and documents. Documents can be passed directly to the API if there are no more than 200 of them.
        /// To go beyond the 200 document limit, documents can be processed offline and then used for efficient retrieval at query time. When `file` is set, the search endpoint searches over all the documents in the given file and returns up to the `max_rerank` number of documents. These documents will be returned along with their search scores.
        /// The similarity score is a positive score that usually ranges from 0 to 300 (but can sometimes go higher), where a score above 200 usually means the document is semantically similar to the query.
        /// </summary>
        /// <param name="engineId">Required parameter: The ID of the engine to use for this request.  You can select one of `ada`, `babbage`, `curie`, or `davinci`..</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateSearchResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateSearchResponse> CreateSearchAsync(
            string engineId,
            Models.CreateSearchRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/engines/{engine_id}/search");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "engine_id", engineId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateSearchResponse>(response.Body);
        }

        /// <summary>
        /// Returns a list of files that belong to the user's organization.
        /// </summary>
        /// <returns>Returns the Models.ListFilesResponse response from the API call.</returns>
        public Models.ListFilesResponse ListFiles()
        {
            var t = ListFilesAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns a list of files that belong to the user's organization.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListFilesResponse response from the API call.</returns>
        public async Task<Models.ListFilesResponse> ListFilesAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/files");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListFilesResponse>(response.Body);
        }

        /// <summary>
        /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
        /// </summary>
        /// <param name="file">Required parameter: Name of the [JSON Lines](https://jsonlines.readthedocs.io/en/latest/) file to be uploaded.  If the `purpose` is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your [training examples](/docs/guides/fine-tuning/prepare-training-data)..</param>
        /// <param name="purpose">Required parameter: The intended purpose of the uploaded documents.  Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tunes). This allows us to validate the format of the uploaded file..</param>
        /// <returns>Returns the Models.OpenAIFile response from the API call.</returns>
        public Models.OpenAIFile CreateFile(
            FileStreamInfo file,
            string purpose)
        {
            var t = CreateFileAsync(file, purpose);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
        /// </summary>
        /// <param name="file">Required parameter: Name of the [JSON Lines](https://jsonlines.readthedocs.io/en/latest/) file to be uploaded.  If the `purpose` is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your [training examples](/docs/guides/fine-tuning/prepare-training-data)..</param>
        /// <param name="purpose">Required parameter: The intended purpose of the uploaded documents.  Use "fine-tune" for [Fine-tuning](/docs/api-reference/fine-tunes). This allows us to validate the format of the uploaded file..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.OpenAIFile response from the API call.</returns>
        public async Task<Models.OpenAIFile> CreateFileAsync(
            FileStreamInfo file,
            string purpose,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/files");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            var fileHeaders = new Dictionary<string, IReadOnlyCollection<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "content-type", new[]
                    {
                        string.IsNullOrEmpty(file.ContentType) ? "application/octect-stream" : file.ContentType
                    }
                }
            };

            // append form/field parameters.
            var fields = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair<string, object>("file", CreateFileMultipartContent(file, fileHeaders)),
                new KeyValuePair<string, object>("purpose", purpose)
            };

            // remove null parameters.
            fields = fields.Where(kvp => kvp.Value != null).ToList();

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Post(queryBuilder.ToString(), headers, fields);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.OpenAIFile>(response.Body);
        }

        /// <summary>
        /// Delete a file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <returns>Returns the Models.DeleteFileResponse response from the API call.</returns>
        public Models.DeleteFileResponse DeleteFile(
            string fileId)
        {
            var t = DeleteFileAsync(fileId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteFileResponse response from the API call.</returns>
        public async Task<Models.DeleteFileResponse> DeleteFileAsync(
            string fileId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/files/{file_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "file_id", fileId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.DeleteFileResponse>(response.Body);
        }

        /// <summary>
        /// Returns information about a specific file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <returns>Returns the Models.OpenAIFile response from the API call.</returns>
        public Models.OpenAIFile RetrieveFile(
            string fileId)
        {
            var t = RetrieveFileAsync(fileId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns information about a specific file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.OpenAIFile response from the API call.</returns>
        public async Task<Models.OpenAIFile> RetrieveFileAsync(
            string fileId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/files/{file_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "file_id", fileId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.OpenAIFile>(response.Body);
        }

        /// <summary>
        /// Returns the contents of the specified file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <returns>Returns the string response from the API call.</returns>
        public string DownloadFile(
            string fileId)
        {
            var t = DownloadFileAsync(fileId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Returns the contents of the specified file.
        /// </summary>
        /// <param name="fileId">Required parameter: The ID of the file to use for this request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the string response from the API call.</returns>
        public async Task<string> DownloadFileAsync(
            string fileId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/files/{file_id}/content");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "file_id", fileId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return response.Body;
        }

        /// <summary>
        /// Answers the specified question using the provided documents and examples.
        /// The endpoint first [searches](/docs/api-reference/searches) over provided documents or files to find relevant context. The relevant context is combined with the provided examples and question to create the prompt for [completion](/docs/api-reference/completions).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateAnswerResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateAnswerResponse CreateAnswer(
            Models.CreateAnswerRequest body)
        {
            var t = CreateAnswerAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Answers the specified question using the provided documents and examples.
        /// The endpoint first [searches](/docs/api-reference/searches) over provided documents or files to find relevant context. The relevant context is combined with the provided examples and question to create the prompt for [completion](/docs/api-reference/completions).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateAnswerResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateAnswerResponse> CreateAnswerAsync(
            Models.CreateAnswerRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/answers");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateAnswerResponse>(response.Body);
        }

        /// <summary>
        /// Classifies the specified `query` using provided examples.
        /// The endpoint first [searches](/docs/api-reference/searches) over the labeled examples.
        /// to select the ones most relevant for the particular query. Then, the relevant examples.
        /// are combined with the query to construct a prompt to produce the final label via the.
        /// [completions](/docs/api-reference/completions) endpoint.
        /// Labeled examples can be provided via an uploaded `file`, or explicitly listed in the.
        /// request using the `examples` parameter for quick tests and small scale use cases.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.CreateClassificationResponse response from the API call.</returns>
        [Obsolete]
        public Models.CreateClassificationResponse CreateClassification(
            Models.CreateClassificationRequest body)
        {
            var t = CreateClassificationAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Classifies the specified `query` using provided examples.
        /// The endpoint first [searches](/docs/api-reference/searches) over the labeled examples.
        /// to select the ones most relevant for the particular query. Then, the relevant examples.
        /// are combined with the query to construct a prompt to produce the final label via the.
        /// [completions](/docs/api-reference/completions) endpoint.
        /// Labeled examples can be provided via an uploaded `file`, or explicitly listed in the.
        /// request using the `examples` parameter for quick tests and small scale use cases.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateClassificationResponse response from the API call.</returns>
        [Obsolete]
        public async Task<Models.CreateClassificationResponse> CreateClassificationAsync(
            Models.CreateClassificationRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/classifications");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.CreateClassificationResponse>(response.Body);
        }

        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// [Learn more about Fine-tuning](/docs/guides/fine-tuning).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public Models.FineTune CreateFineTune(
            Models.CreateFineTuneRequest body)
        {
            var t = CreateFineTuneAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// [Learn more about Fine-tuning](/docs/guides/fine-tuning).
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public async Task<Models.FineTune> CreateFineTuneAsync(
            Models.CreateFineTuneRequest body,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/fine-tunes");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" }
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.FineTune>(response.Body);
        }

        /// <summary>
        /// List your organization's fine-tuning jobs.
        /// </summary>
        /// <returns>Returns the Models.ListFineTunesResponse response from the API call.</returns>
        public Models.ListFineTunesResponse ListFineTunes()
        {
            var t = ListFineTunesAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// List your organization's fine-tuning jobs.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListFineTunesResponse response from the API call.</returns>
        public async Task<Models.ListFineTunesResponse> ListFineTunesAsync(
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/fine-tunes");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListFineTunesResponse>(response.Body);
        }

        /// <summary>
        /// Gets info about the fine-tune job.
        /// [Learn more about Fine-tuning](/docs/guides/fine-tuning).
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job.</param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public Models.FineTune RetrieveFineTune(
            string fineTuneId)
        {
            var t = RetrieveFineTuneAsync(fineTuneId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Gets info about the fine-tune job.
        /// [Learn more about Fine-tuning](/docs/guides/fine-tuning).
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public async Task<Models.FineTune> RetrieveFineTuneAsync(
            string fineTuneId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/fine-tunes/{fine_tune_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "fine_tune_id", fineTuneId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.FineTune>(response.Body);
        }

        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job to cancel.</param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public Models.FineTune CancelFineTune(
            string fineTuneId)
        {
            var t = CancelFineTuneAsync(fineTuneId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job to cancel.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.FineTune response from the API call.</returns>
        public async Task<Models.FineTune> CancelFineTuneAsync(
            string fineTuneId,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/fine-tunes/{fine_tune_id}/cancel");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "fine_tune_id", fineTuneId }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Post(queryBuilder.ToString(), headers, null);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.FineTune>(response.Body);
        }

        /// <summary>
        /// Get fine-grained status updates for a fine-tune job.
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job to get events for..</param>
        /// <param name="stream">Optional parameter: Whether to stream events for the fine-tune job. If set to true, events will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available. The stream will terminate with a `data: [DONE]` message when the job is finished (succeeded, cancelled, or failed).  If set to false, only events generated so far will be returned..</param>
        /// <returns>Returns the Models.ListFineTuneEventsResponse response from the API call.</returns>
        public Models.ListFineTuneEventsResponse ListFineTuneEvents(
            string fineTuneId,
            bool? stream = false)
        {
            var t = ListFineTuneEventsAsync(fineTuneId, stream);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Get fine-grained status updates for a fine-tune job.
        /// </summary>
        /// <param name="fineTuneId">Required parameter: The ID of the fine-tune job to get events for..</param>
        /// <param name="stream">Optional parameter: Whether to stream events for the fine-tune job. If set to true, events will be sent as data-only [server-sent events](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events#Event_stream_format) as they become available. The stream will terminate with a `data: [DONE]` message when the job is finished (succeeded, cancelled, or failed).  If set to false, only events generated so far will be returned..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListFineTuneEventsResponse response from the API call.</returns>
        public async Task<Models.ListFineTuneEventsResponse> ListFineTuneEventsAsync(
            string fineTuneId,
            bool? stream = false,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/fine-tunes/{fine_tune_id}/events");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "fine_tune_id", fineTuneId }
            });

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "stream", stream != null ? stream : false }
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers, queryParams);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListFineTuneEventsResponse>(response.Body);
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
        /// </summary>
        /// <returns>Returns the Models.ListModelsResponse response from the API call.</returns>
        public Models.ListModelsResponse ListModels()
        {
            var t = ListModelsAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListModelsResponse response from the API call.</returns>
        public async Task<Models.ListModelsResponse> ListModelsAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/models");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.ListModelsResponse>(response.Body);
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        /// </summary>
        /// <param name="model">Required parameter: The ID of the model to use for this request.</param>
        /// <returns>Returns the Models.Model response from the API call.</returns>
        public Models.Model RetrieveModel(
            string model)
        {
            var t = RetrieveModelAsync(model);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        /// </summary>
        /// <param name="model">Required parameter: The ID of the model to use for this request.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Model response from the API call.</returns>
        public async Task<Models.Model> RetrieveModelAsync(
            string model,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/models/{model}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "model", model }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.Model>(response.Body);
        }

        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization.
        /// </summary>
        /// <param name="model">Required parameter: The model to delete.</param>
        /// <returns>Returns the Models.DeleteModelResponse response from the API call.</returns>
        public Models.DeleteModelResponse DeleteModel(
            string model)
        {
            var t = DeleteModelAsync(model);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization.
        /// </summary>
        /// <param name="model">Required parameter: The model to delete.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteModelResponse response from the API call.</returns>
        public async Task<Models.DeleteModelResponse> DeleteModelAsync(
            string model,
            CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            var baseUri = Config.GetBaseUri();

            // prepare query string for API call.
            var queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/models/{model}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "model", model }
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", UserAgent },
                { "accept", "application/json" }
            };

            // prepare the API call request to fetch the response.
            var httpRequest = GetClientInstance().Delete(queryBuilder.ToString(), headers, null);

            if (HttpCallBack != null) HttpCallBack.OnBeforeHttpRequestEventHandler(GetClientInstance(), httpRequest);

            httpRequest = await AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            var response = await GetClientInstance()
                .ExecuteAsStringAsync(httpRequest, cancellationToken: cancellationToken).ConfigureAwait(false);
            var context = new HttpContext(httpRequest, response);
            if (HttpCallBack != null) HttpCallBack.OnAfterHttpResponseEventHandler(GetClientInstance(), response);

            // handle errors defined at the API level.
            ValidateResponse(response, context);

            return ApiHelper.JsonDeserialize<Models.DeleteModelResponse>(response.Body);
        }
    }
}