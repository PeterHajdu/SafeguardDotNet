using System;
using System.Collections.Generic;
using OneIdentity.SafeguardDotNet.Event;
using RestSharp;
using RestSharp.Authenticators;
using System.Security;

namespace OneIdentity.SafeguardDotNet
{
    /// <summary>
    /// This is the reusable connection interface that can be used to call SPS API.
    /// </summary>
    internal class SafeguardSessionsConnection : ISafeguardSessionsConnection
    {
        private readonly RestClient _client;
        public SafeguardSessionsConnection(string networkAddress, string username,
            SecureString password, bool ignoreSsl = false)
        {
            var spsApiUrl = $"https://{networkAddress}/api";
            _client = new RestClient(spsApiUrl);
            _client.Authenticator = new HttpBasicAuthenticator(username, password.ToInsecureString());
            if (ignoreSsl)
            {
                _client.RemoteCertificateValidationCallback += (sender, certificate, chain, errors) => true;
            }
            var request = new RestRequest("authentication", RestSharp.Method.GET);
            var response = _client.Get(request);
            if (!response.IsSuccessful)
                throw new SafeguardDotNetException(
                    "Error returned when authenticating to sps api, Error: " + $"{response.StatusCode} {response.Content}",
                    response.StatusCode, response.Content);
            Console.WriteLine("printing conn result");
            Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Call a Safeguard API method and get a detailed response with status code, headers,
        /// and body. If there is a failure a SafeguardDotNetException will be thrown.
        /// </summary>
        /// <param name="method">Safeguard method type to use.</param>
        /// <param name="body">Request body to pass to the method.</param>
        /// <param name="parameters">Additional parameters to add to the URL.</param>
        /// <param name="additionalHeaders">Additional headers to add to the request.</param>
        /// <param name="timeout">Optional per-request timeout</param>
        /// <returns>Response with status code, headers, and body as string.</returns>
        public FullResponse InvokeMethodFull(Method method, string relativeUrl,
            string body = null, IDictionary<string, string> parameters = null,
            IDictionary<string, string> additionalHeaders = null,
            TimeSpan? timeout = null)
        {
            var request = new RestRequest(relativeUrl, method.ConvertToRestSharpMethod());
            if ((method == Method.Post || method == Method.Put) && body != null)
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _client.Execute(request);

            return new FullResponse
            {
                StatusCode = response.StatusCode,
                Headers = new Dictionary<string, string>(),
                Body = response.Content
            };
        }
    }
}
