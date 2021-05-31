﻿using System;
using System.Collections.Generic;
using OneIdentity.SafeguardDotNet.Event;
using RestSharp;
using RestSharp.Authenticators;

namespace OneIdentity.SafeguardDotNet
{
    /// <summary>
    /// This is the reusable connection interface that can be used to call SPS API.
    /// </summary>
    public class SafeguardSessionsConnection : ISafeguardSessionsConnection
    {
        private readonly RestClient _client;
        public SafeguardSessionsConnection(string networkAddress)
        {
            var spsApiUrl = $"https://{networkAddress}/api";
            _client = new RestClient(spsApiUrl);

            // curl --basic --user "admin:PYszFHvC>66BiI-TL7W3" --cookie-jar cookies --insecure https://20.76.79.111:4000/api/authentication
            _client.Authenticator = new HttpBasicAuthenticator("admin", "a");
            var request = new RestRequest("authentication", RestSharp.Method.GET);
            _client.Execute(request);
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
                StatusCode = response.StatusCode,
                Headers = new Dictionary<string, string>(),
                Body = response.Content
            };
        }
    }
}
