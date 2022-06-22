// <copyright file="HttpClientWrapper.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>

namespace OpenAIAPI.Standard.Http.Client
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Polly.Retry;
    using Polly.Timeout;
    using Polly.Wrap;
    using Request;
    using Request.Configuration;
    using Response;
    using Utilities;

    /// <summary>
    /// HttpClientWrapper.
    /// </summary>
    internal sealed class HttpClientWrapper : IHttpClient
    {
        private static char parameterSeparator = '&';
        private readonly int numberOfRetries;
        private readonly int backoffFactor;
        private readonly double retryInterval;
        private readonly TimeSpan maximumRetryWaitTime;
        private ArrayDeserialization arrayDeserializationFormat = ArrayDeserialization.Indexed;
        private HttpClient client;
        private IList<HttpStatusCode> statusCodesToRetry;
        private IList<HttpMethod> requestMethodsToRetry;
        private bool overrideHttpClientConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpClientWrapper"/> class.
        /// </summary>
        /// <param name="httpClientConfig"> HttpClientConfiguration object.</param>
        public HttpClientWrapper(HttpClientConfiguration httpClientConfig)
        {
            client = httpClientConfig.HttpClientInstance;
            overrideHttpClientConfiguration = httpClientConfig.OverrideHttpClientConfiguration;

            if (overrideHttpClientConfiguration)
            {
                statusCodesToRetry = httpClientConfig.StatusCodesToRetry
                    .Where(val => Enum.IsDefined(typeof(HttpStatusCode), val))
                    .Select(val => (HttpStatusCode)val).ToImmutableList();

                requestMethodsToRetry = httpClientConfig.RequestMethodsToRetry
                    .Select(method => new HttpMethod(method.ToString())).ToList();

                numberOfRetries = httpClientConfig.NumberOfRetries;
                backoffFactor = httpClientConfig.BackoffFactor;
                retryInterval = httpClientConfig.RetryInterval;
                maximumRetryWaitTime = httpClientConfig.MaximumRetryWaitTime;
                client.Timeout = httpClientConfig.Timeout;
            }
        }

        /// <summary>
        /// OnBeforeHttpRequestEvent.
        /// </summary>
        public event OnBeforeHttpRequestEventHandler OnBeforeHttpRequestEvent;

        /// <summary>
        /// OnAfterHttpResponseEvent.
        /// </summary>
        public event OnAfterHttpResponseEventHandler OnAfterHttpResponseEvent;

        /// <summary>
        /// Executes the http request.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="retryConfiguration">The <see cref="RetryConfiguration"/> for request.</param>
        /// <returns>HttpStringResponse.</returns>
        public HttpStringResponse ExecuteAsString(HttpRequest request, RetryConfiguration retryConfiguration = null)
        {
            var t = ExecuteAsStringAsync(request, retryConfiguration);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Executes the http request asynchronously.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="cancellationToken"> cancellationToken.</param>
        /// <param name="retryConfiguration">The <see cref="RetryConfiguration"/> for request.</param>
        /// <returns>Returns the HttpStringResponse.</returns>
        public async Task<HttpStringResponse> ExecuteAsStringAsync(
            HttpRequest request,
            RetryConfiguration retryConfiguration = null,
            CancellationToken cancellationToken = default)
        {
            // raise the on before request event.
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage;

            if (overrideHttpClientConfiguration)
                responseMessage = await GetCombinedPolicy(retryConfiguration).ExecuteAsync(
                        async (cancellation) => await HttpResponseMessage(request, cancellation).ConfigureAwait(false),
                        cancellationToken)
                    .ConfigureAwait(false);
            else
                responseMessage = await HttpResponseMessage(request, cancellationToken).ConfigureAwait(false);

            var statusCode = (int)responseMessage.StatusCode;
            var headers = GetCombinedResponseHeaders(responseMessage);
            var rawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var body = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = new HttpStringResponse(statusCode, headers, rawBody, body);

            // raise the on after response event.
            RaiseOnAfterHttpResponseEvent(response);

            return response;
        }

        /// <summary>
        /// Executes the http request.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="retryConfiguration">The <see cref="RetryConfiguration"/> for request.</param>
        /// <returns>HttpResponse.</returns>
        public HttpResponse ExecuteAsBinary(HttpRequest request, RetryConfiguration retryConfiguration = null)
        {
            var t = ExecuteAsBinaryAsync(request, retryConfiguration);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Executes the http request asynchronously.
        /// </summary>
        /// <param name="request">Http request.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <param name="retryConfiguration">The <see cref="RetryConfiguration"/> for request.</param>
        /// <returns>HttpResponse.</returns>
        public async Task<HttpResponse> ExecuteAsBinaryAsync(
            HttpRequest request,
            RetryConfiguration retryConfiguration = null,
            CancellationToken cancellationToken = default)
        {
            // raise the on before request event.
            RaiseOnBeforeHttpRequestEvent(request);

            HttpResponseMessage responseMessage;

            if (overrideHttpClientConfiguration)
                responseMessage = await GetCombinedPolicy(retryConfiguration).ExecuteAsync(
                        async (cancellation) => await HttpResponseMessage(request, cancellation).ConfigureAwait(false),
                        cancellationToken)
                    .ConfigureAwait(false);
            else
                responseMessage = await HttpResponseMessage(request, cancellationToken).ConfigureAwait(false);

            var statusCode = (int)responseMessage.StatusCode;
            var headers = GetCombinedResponseHeaders(responseMessage);
            var rawBody = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var response = new HttpResponse(statusCode, headers, rawBody);

            // raise the on after response event.
            RaiseOnAfterHttpResponseEvent(response);

            return response;
        }

        /// <summary>
        /// Get http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Get(
            string queryUrl,
            Dictionary<string, string> headers,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Get, queryUrl, headers, username, password, queryParameters);

        /// <summary>
        /// Get http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Get(string queryUrl) => new HttpRequest(HttpMethod.Get, queryUrl);

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Post(string queryUrl) => new HttpRequest(HttpMethod.Post, queryUrl);

        /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Put(string queryUrl) => new HttpRequest(HttpMethod.Put, queryUrl);

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Delete(string queryUrl) => new HttpRequest(HttpMethod.Delete, queryUrl);

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Patch(string queryUrl) => new HttpRequest(new HttpMethod("PATCH"), queryUrl);

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Post(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Post, queryUrl, headers, formParameters, username, password, queryParameters);

        /// <summary>
        /// Post http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PostBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Post, queryUrl, headers, body, username, password, queryParameters);

        /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Put(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Put, queryUrl, headers, formParameters, username, password, queryParameters);

        /// <summary>
        /// Put http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PutBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Put, queryUrl, headers, body, username, password, queryParameters);

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Patch(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, formParameters, username, password,
                queryParameters);

        /// <summary>
        /// Patch http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest PatchBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(new HttpMethod("PATCH"), queryUrl, headers, body, username, password, queryParameters);

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="formParameters">formParameters.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest Delete(
            string queryUrl,
            Dictionary<string, string> headers,
            List<KeyValuePair<string, object>> formParameters,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Delete, queryUrl, headers, formParameters, username, password, queryParameters);

        /// <summary>
        /// Delete http request.
        /// </summary>
        /// <param name="queryUrl">queryUrl.</param>
        /// <param name="headers">headers.</param>
        /// <param name="body">body.</param>
        /// <param name="queryParameters">queryParameters.</param>
        /// <param name="username">username.</param>
        /// <param name="password">password.</param>
        /// <returns>HttpRequest.</returns>
        public HttpRequest DeleteBody(
            string queryUrl,
            Dictionary<string, string> headers,
            object body,
            Dictionary<string, object> queryParameters = null,
            string username = null,
            string password = null) =>
            new HttpRequest(HttpMethod.Delete, queryUrl, headers, body, username, password, queryParameters);

        private static Dictionary<string, string> GetCombinedResponseHeaders(HttpResponseMessage responseMessage)
        {
            var headers = responseMessage.Headers.ToDictionary(l => l.Key, k => k.Value.First());
            if (responseMessage.Content != null)
                foreach (var contentHeader in responseMessage.Content.Headers)
                {
                    if (headers.ContainsKey(contentHeader.Key)) continue;

                    headers.Add(contentHeader.Key, contentHeader.Value.First());
                }

            return headers;
        }

        private void RaiseOnBeforeHttpRequestEvent(HttpRequest request)
        {
            if (OnBeforeHttpRequestEvent != null && request != null) OnBeforeHttpRequestEvent(this, request);
        }

        private void RaiseOnAfterHttpResponseEvent(HttpResponse response)
        {
            if (OnAfterHttpResponseEvent != null && response != null) OnAfterHttpResponseEvent(this, response);
        }

        private async Task<HttpResponseMessage> HttpResponseMessage(
            HttpRequest request,
            CancellationToken cancellationToken)
        {
            var queryBuilder = new StringBuilder(request.QueryUrl);

            if (request.QueryParameters != null)
                ApiHelper.AppendUrlWithQueryParameters(queryBuilder, request.QueryParameters,
                    arrayDeserializationFormat, parameterSeparator);

            // validate and preprocess url.
            var queryUrl = ApiHelper.CleanUrl(queryBuilder);

            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(queryUrl),
                Method = request.HttpMethod
            };

            if (request.Headers != null)
                foreach (var headers in request.Headers)
                    requestMessage.Headers.TryAddWithoutValidation(headers.Key, headers.Value);

            if (!string.IsNullOrEmpty(request.Username))
            {
                var byteArray = Encoding.UTF8.GetBytes(request.Username + ":" + request.Password);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(
                    "Basic",
                    Convert.ToBase64String(byteArray));
            }

            if (request.HttpMethod.Equals(HttpMethod.Delete) || request.HttpMethod.Equals(HttpMethod.Post) ||
                request.HttpMethod.Equals(HttpMethod.Put) || request.HttpMethod.Equals(new HttpMethod("PATCH")))
            {
                var multipartRequest = request.FormParameters != null &&
                                       (request.FormParameters.Any(f => f.Value is MultipartContent) ||
                                        request.FormParameters.Any(f => f.Value is FileStreamInfo));

                if (request.Body != null)
                {
                    var contentType = request.Headers.Where(p =>
                            p.Key.Equals("content-type", StringComparison.InvariantCultureIgnoreCase))
                        .Select(x => x.Value)
                        .FirstOrDefault();

                    if (request.Body is FileStreamInfo file)
                    {
                        file.FileStream.Position = 0;
                        requestMessage.Content = new StreamContent(file.FileStream);
                        if (!string.IsNullOrWhiteSpace(file.ContentType))
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                        else if (!string.IsNullOrEmpty(contentType))
                            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                        else
                            requestMessage.Content.Headers.ContentType =
                                new MediaTypeHeaderValue("application/octet-stream");
                    }
                    else if (!string.IsNullOrEmpty(contentType) && contentType.Equals("application/json; charset=utf-8",
                                 StringComparison.OrdinalIgnoreCase))
                    {
                        requestMessage.Content = new StringContent((string)request.Body ?? string.Empty, Encoding.UTF8,
                            "application/json");
                    }
                    else if (!string.IsNullOrEmpty(contentType))
                    {
                        byte[] bytes = null;

                        if (request.Body is Stream)
                        {
                            var s = (Stream)request.Body;
                            s.Position = 0;
                            using (var br = new BinaryReader(s))
                            {
                                bytes = br.ReadBytes((int)s.Length);
                            }
                        }
                        else if (request.Body is byte[])
                        {
                            bytes = (byte[])request.Body;
                        }
                        else
                        {
                            bytes = Encoding.UTF8.GetBytes((string)request.Body);
                        }

                        requestMessage.Content = new ByteArrayContent(bytes ?? Array.Empty<byte>());

                        try
                        {
                            requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
                        }
                        catch (Exception)
                        {
                            requestMessage.Content.Headers.TryAddWithoutValidation("content-type", contentType);
                        }
                    }
                    else
                    {
                        requestMessage.Content = new StringContent(request.Body.ToString() ?? string.Empty,
                            Encoding.UTF8, "text/plain");
                    }
                }
                else if (multipartRequest)
                {
                    var formContent = new MultipartFormDataContent();

                    foreach (var param in request.FormParameters)
                        if (param.Value is FileStreamInfo fileParam)
                        {
                            var fileContent = new MultipartFileContent(fileParam);
                            fileContent.Rewind();
                            formContent.Add(fileContent.ToHttpContent(param.Key));
                        }
                        else if (param.Value is MultipartContent wrapperObject)
                        {
                            wrapperObject.Rewind();
                            formContent.Add(wrapperObject.ToHttpContent(param.Key));
                        }
                        else
                        {
                            formContent.Add(new StringContent(param.Value.ToString()), param.Key);
                        }

                    requestMessage.Content = formContent;
                }
                else if (request.FormParameters != null)
                {
                    var parameters = new List<KeyValuePair<string, string>>();
                    foreach (var param in request.FormParameters)
                        parameters.Add(new KeyValuePair<string, string>(param.Key, param.Value.ToString()));

                    requestMessage.Content = new FormUrlEncodedContent(parameters);
                }
            }

            return await client.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        private bool ShouldRetry(HttpResponseMessage response, RetryConfiguration retryConfiguration)
        {
            var isWhiteListedMethod = requestMethodsToRetry.Contains(response.RequestMessage.Method);

            return retryConfiguration.RetryOption.IsRetryAllowed(isWhiteListedMethod) &&
                   (statusCodesToRetry.Contains(response.StatusCode) || response?.Headers?.RetryAfter != null);
        }

        private TimeSpan GetServerWaitDuration(DelegateResult<HttpResponseMessage> response)
        {
            var retryAfter = response?.Result?.Headers?.RetryAfter;
            if (retryAfter == null) return TimeSpan.Zero;

            return retryAfter.Date.HasValue
                ? retryAfter.Date.Value - DateTime.UtcNow
                : retryAfter.Delta.GetValueOrDefault(TimeSpan.Zero);
        }

        private AsyncRetryPolicy<HttpResponseMessage> GetRetryPolicy(RetryConfiguration retryConfiguration)
        {
            return Policy.HandleResult<HttpResponseMessage>(response => ShouldRetry(response, retryConfiguration))
                .Or<TaskCanceledException>()
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(
                    numberOfRetries,
                    (retryAttempt, result, context) =>
                        TimeSpan.FromMilliseconds(Math.Max(GetExponentialWaitTime(retryAttempt),
                            GetServerWaitDuration(result).TotalMilliseconds)),
                    async (result, timespan, retryAttempt, context) => await Task.CompletedTask);
        }

        private AsyncTimeoutPolicy GetTimeoutPolicy() =>
            maximumRetryWaitTime.TotalSeconds == 0
                ? Policy.TimeoutAsync(Timeout.InfiniteTimeSpan)
                : Policy.TimeoutAsync(maximumRetryWaitTime);

        private AsyncPolicyWrap<HttpResponseMessage> GetCombinedPolicy(RetryConfiguration retryConfiguration = null)
        {
            if (retryConfiguration == null) retryConfiguration = DefaultRetryConfiguration.RetryConfiguration;

            return GetTimeoutPolicy().WrapAsync(GetRetryPolicy(retryConfiguration));
        }

        private double GetExponentialWaitTime(int retryAttempt)
        {
            var noise = new Random().NextDouble() * 100;
            return 1000 * retryInterval * Math.Pow(backoffFactor, retryAttempt - 1) + noise;
        }
    }
}