﻿using System;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace OneIdentity.SafeguardDotNet.Authentication
{
    internal class CertificateAuthenticator : AuthenticatorBase
    {
        private readonly string _certificateThumbprint;
        private readonly string _certificatePath;
        private readonly SecureString _certificatePassword;

        public CertificateAuthenticator(string networkAddress, string certificateThumbprint, int apiVersion,
            bool ignoreSsl) : base(networkAddress, apiVersion, ignoreSsl)
        {
            _certificateThumbprint = certificateThumbprint;
        }

        public CertificateAuthenticator(string networkAddress, string certificatePath, SecureString certificatePassword,
            int apiVersion, bool ignoreSsl) : base(networkAddress, apiVersion, ignoreSsl)
        {
            _certificatePath = certificatePath;
            _certificatePassword = certificatePassword;
        }

        protected override SecureString GetRstsTokenInternal()
        {
            var request = new RestRequest("oauth2/token", RestSharp.Method.POST)
                .AddHeader("Accept", "application/json")
                .AddHeader("Content-type", "application/json")
                .AddJsonBody(new
                {
                    grant_type = "client_credentials",
                    scope = "rsts:sts:primaryproviderid:certificate"
                });
            var userCert = !string.IsNullOrEmpty(_certificateThumbprint)
                ? CertificateUtilities.GetClientCertificateFromStore(_certificateThumbprint)
                : CertificateUtilities.GetClientCertificateFromFile(_certificatePath, _certificatePassword);
            RstsClient.ClientCertificates = new X509Certificate2Collection() { userCert };
            var response = RstsClient.Execute(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
                throw new Exception($"Unable to connect to RSTS service {RstsClient.BaseUrl}, Error: " +
                                    response.ErrorMessage);
            if (!response.IsSuccessful)
                throw new Exception("Error using client_credentials grant_type with " +
                                    $"{(string.IsNullOrEmpty(_certificatePath) ? $"thumbprint={_certificateThumbprint}" : $"file={_certificatePath}")}" +
                                    $", Error: {response.StatusCode} {response.Content}");
            var jObject = JObject.Parse(response.Content);
            return jObject.GetValue("access_token").ToString().ToSecureString();
        }
    }
}
