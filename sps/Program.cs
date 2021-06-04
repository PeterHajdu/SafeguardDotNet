using System;
using OneIdentity.SafeguardDotNet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace sps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var spsPass = "aaaa".ToSecureString();
            var spsConn = SafeguardForPrivilegedSessions.Connect("ip", "admin", spsPass, true);
            Console.WriteLine("sps connect ok");

            // var certChain = "-----BEGIN CERTIFICATE-----\nMIIDFjCIBAgIJALnoMlTK4LZYMA0GCSqGSIb3DQEBCwUAMDgxEDAOBgNV\nBAoTB0FsY2hlbXkxDjAMBgNVBAsTBXZpYTEyMRQwEgYDVQQDEwtjYS52aWExMi5p\nbzAeFw0yMTA2MDMxMzUwMDFaFw0zMTA2MDMxMzUwMDFaMDgxEDAOBgNVBAoTB0Fs\nY2hlbXkxDjAMBgNVBAsTBXZpYTEyMRQwEgYDVQQDEwtjYS52aWExMi5pbzCCASIw\nDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBANdhiHZ3x5OIi8vq4HeXvRvKWClS\nWJJq8n3gCVr0utZxGvWkmRWQWs/v3qa7KWRY2gdvuVlg4iT+4Jh5teG/WduEamW4\nyjevxBXevoDZVfvDoZawgownGxuWOfPBEIVnzaoQ4yTG0Ge611STIbG8kZaNWrpa\nFBAw3uWUZVMIA2a0trZee7S2Sn+StH3oLdgWv1kb5Y5qciukTmW/POg2qz28AzzB\n3hjy5ZeP+gi3+DgAWRJWpmaMRxmwRu3+9+UZaINTe1NwaWxcSkt8CizUmiU94HQ/\nyrn9ZhdI+ZwmZMV7ObWZx7UeSiD8PXbeBqy32Ul9QCUYZ1e3lEcef26EAPcCAwEA\nAaMjMCEwDwYDVR0TAQH/BAUwAwEB/zAOBgNVHQ8BAf8EBAMCAQYwDQYJKoZIhvcN\nAQELBQADggEBAC+/j1Ogfk4g2SpnWRG420rK0q6i/+ZGzBtmLoE7nxRADlDxERBb\nTKtMbwDF5GoL/dnY3kvLkGZYDLaiiZxlKsM0YP4iGIgw4F2X4D0LaWQfDoPpHfJE\niX651983BBqhfLAUjaWh/Ro8QUss9Zm3cdqS8Q1DwUKtn0RkIuLCf9s/gX5ul3ro\nmdtuzULPauEQJFq4aZisWBpklRMJS40u0VcJgi8+atOnSl3lQP0Ns6a/hPkKXbk1\n2ASxCFQ2CMAeiVDRZIjLBErI8Vn5VgNs1mzXm3/jMhTrghbJXpHY616IJ6lkDA1V\nE++z2rXimZvXDpyvOJP2u5mF0COBZdE3Tgc=\n-----END CERTIFICATE-----\n-----BEGIN CERTIFICATE-----\nMIIDQDCCAiigAwIBAgIRAJmHC6IFVZtOhNDuMRQilq0wDQYJKoZIhvcNAQELBQAw\nODEQMA4GA1UEChMHQWxjaGVteTEOMAwGA1UECxMFdmlhMTIxFDASBgNVBAMTC2Nh\nLnZpYTEyLmlvMB4XDTIxMDYwMzEzNTAwMVoXDTMwMDYwMzEzNTAwMVowOzEQMA4G\nA1UEChMHQWxjaGVteTEOMAwGA1UECxMFdmlhMTIxFzAVBgNVBAMTDnNwcC0xLnZp\nYTEyLmlvMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvq6vunvzKb0j\n/9XGBr84ZIws54QlcxtXBxWOMjz5q2wEfbMfzbJluSrmApKJfSIpGdeTWQu1+uf8\nN1lGfbhwdnuLH+ZlR/qDs+8LMytyk/YJfKQ9lJVG30Kc9lUIma2UXkJbiN9WccT1\nJkzj5IF0HjgOQW+kA4fIBoqMc97UZFWyg5hNlgH9ieEj3TEEdBL1d5u0qqP0Z0Ak\nVV4C8Ux0E66NBXt+O6q+IB1rAtb6EXOHeenAWnepgKoA/Dis0L5NDxuPeJLFXaV5\nRGt2+uVeq41P5YVdw3zHRcZPn085KlKHhPj2CAfWUQ3PJKX8VewLrVHNNCarJcgL\nl+U/2O8RKQIDAQABo0IwQDAOBgNVHQ8BAf8EBAMCA6gwEwYDVR0lBAwwCgYIKwYB\nBQUHAwEwGQYDVR0RBBIwEIIOc3BwLTEudmlhMTIuaW8wDQYJKoZIhvcNAQELBQAD\nggEBAGzaCkTCcwWtFmbzbfsK0KVF/8AKu+7comBiChklEGwG1/P7z0QzwzaEh+Kv\nZrePzvDEmFeltdMAX4BnKP740Duk323wmtCLkI4FWRsehBgAYxv7FrvJwfKSZpZp\n+Bkafhyt4ahWTyW/1CMN7n9k+mNuGcSfrtg/qPbokmQG61HT1F+JXdAYymL9+q2e\nao+jRaimUKSlXB29xZhbOfeNZdNpZa5PZCpHwnimwM6NewFcEDJx0Msb9QNRTlBu\n2Vyo5EArGmK+i/XQgfXuILXJkIqAzQNqIFYaHlrwMTS2BLlISgDwYAGncV\nIgfAT0X79bq+E7RQpj3tkrkO88Y=\n-----END CERTIFICATE-----\n";
            // var sppPass = "aaaaaa".ToSecureString();
            // var sppConn = Safeguard.Connect("ip", "local", "admin", sppPass, 3, true);
            // Console.WriteLine("spp connect ok");

            EnableClusterInterfaceOnSps(spsConn);
            PromoteSpsToCentralManagement(spsConn);

            // var joinResponse = sppConn.JoinSPS(spsConn, certChain, "ioiio");
            // Console.WriteLine("join finished with response:");
            // Console.WriteLine(joinResponse.Body);

            // Console.WriteLine("status");
            // var statusResponse = spsConn.InvokeMethodFull(Method.Get, "cluster/spp", "{}");
            // Console.WriteLine(statusResponse.Body);

        }

        internal static void EnableClusterInterfaceOnSps(ISafeguardSessionsConnection SpsConnection)
        {
            var getClusterStatusResponse = SpsConnection.InvokeMethodFull(Method.Get, "configuration/local_services/admin_web");
            JObject obj = JObject.Parse(getClusterStatusResponse.Body);
            string listenAddress = (string)obj["body"]["listen"][0]["address"]["key"];

            SpsConnection.InvokeMethodFull(Method.Post, "transaction");

            var clusterIf = new SpsClusterRequest
            {
                enabled = true,
                listen_address = listenAddress
            };
            var clusterBody = JsonConvert.SerializeObject(clusterIf);

            var enableClusterResponse = SpsConnection.InvokeMethodFull(Method.Put, "configuration/local_services/cluster", clusterBody);
            Console.WriteLine("cluster enable response:");
            Console.WriteLine(enableClusterResponse.Body);

            SpsConnection.InvokeMethodFull(Method.Put, "transaction");
        }

        internal static void PromoteSpsToCentralManagement(ISafeguardSessionsConnection SpsConnection)
        {
            SpsConnection.InvokeMethodFull(Method.Post, "transaction");

            var promoteResponse = SpsConnection.InvokeMethodFull(Method.Post, "cluster/promote");
            Console.WriteLine("promote response:");
            Console.WriteLine(promoteResponse.Body);

            SpsConnection.InvokeMethodFull(Method.Put, "transaction");
        }
    }
}
