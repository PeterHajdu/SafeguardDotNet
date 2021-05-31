using System;
using System.Collections.Generic;
using OneIdentity.SafeguardDotNet.Event;
using RestSharp;
using OneIdentity.SafeguardDotNet.Authentication;

namespace OneIdentity.SafeguardDotNet
{
    /// <summary>
    /// This is the reusable connection interface that can be used to call SPS API.
    /// </summary>
    internal class SafeguardSessionsConnection : ISafeguardSessionsConnection
    {
        private readonly RestClient _client;
        public SafeguardSessionsConnection(IAuthenticationMechanism authenticationMechanism)
        {
            var spsApiUrl = $"https://{authenticationMechanism.NetworkAddress}/api";
            _client = new RestClient(spsApiUrl);
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
            var response = _client.Execute(request);

            return new FullResponse
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Headers = new Dictionary<string, string>(),
                Body = ""
            };
        }
    }
}
