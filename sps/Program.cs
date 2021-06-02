using System;
using System.Security;
using OneIdentity.SafeguardDotNet;

namespace sps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var spsPass = new SecureString();
            spsPass.AppendChar('a');
            var spsConn = SafeguardForPrivilegedSessions.Connect("10.12.224.172", "admin", spsPass, true);
            Console.WriteLine("sps connect ok");

            var certChain = "-----BEGIN CERTIFICATE-----\nMIIDRDCCAiygAwIBAgIQdIteOSyG3UaxGOAGkasZ/zANBgkqhkiG9w0BAQsFADA6\nMRAwDgYDVQQKEwdBbGNoZW15MQ8wDQYDVQQLEwZocHRyMjIxFTATBgNVBAMTDGNh\nLmhwdHIyMi5pbzAeFw0yMTA1MjAxMDQ0MTJaFw0zMDA1MjAxMDQ0MTJaMD0xEDAO\nBgNVBAoTB0FsY2hlbXkxDzANBgNVBAsTBmhwdHIyMjEYMBYGA1UEAxMPc3BwLTEu\naHB0cjIyLmlvMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwjYSORQl\nLDRwo/z8SD1FEB5wR2p6XcFE7lmsv67NarKrd0xhum4LuQWQ5d3xZSavrzwcfqno\nEwoDQYKi0SBb1egNfBxmsK7xhLqs5b+hqgxc8wDYvwn3VdRYBwGp0JRHT/PAmfSm\natIKUy4MBQdxMWmkw1F9ENJzwblgMi+imoRt0Z/WOne5/4OnqaMgx+2ijjT1r/uz\ngXNpozE5V77XJu/Xvk3TLtRPrYOSjRxUJgt+6Z0nB1likz5LlmDQoYIDTzsXmdhy\npWtHUtMdHzsZYz8Pb0bg/FQSNuh+/iLi/ikLRhPEbA4efFsSg05mUe2494I7PGHX\ncst8V4C5I79vAQIDAQABo0MwQTAOBgNVHQ8BAf8EBAMCA6gwEwYDVR0lBAwwCgYI\nKwYBBQUHAwEwGgYDVR0RBBMwEYIPc3BwLTEuaHB0cjIyLmlvMA0GCSqGSIb3DQEB\nCwUAA4IBAQCbqZaVNWveVIfWe/5Ddr/LTRxUjDTOCIiHl77eBm0XB7oHgy9hH2tJ\nMNPfgTHPlJiZn+mEVT0/XRD3qd9rcYo247j5qM2ddcmjGPM6vUIbVhT1FRQl74Lg\nGRGfhd5Ttfca3vN0044xpX7Yt7wJX8NBZRYF0q9Ctb5Ymy+x9jiyePIHinBZm9Jj\n7yfYxVs4KlAj68P+0SlfYAZZ+kqLVADu7gh3kfkiESsbDJN4UioxxwwfkMmkzIHU\nj/ett5RWTmLcaKZF9Ykl61ScUCn9GWcGU2obyyYhft8K3y3ow1VqftYV/dwrBUwC\nafvg4WfFtNl+axtZN8YOZxQUhRGq1ZqH\n-----END CERTIFICATE-----\n-----BEGIN CERTIFICATE-----\nMIIDGjCCAgKgAwIBAgIJAKW3XEGptUF0MA0GCSqGSIb3DQEBCwUAMDoxEDAOBgNV\nBAoTB0FsY2hlbXkxDzANBgNVBAsTBmhwdHIyMjEVMBMGA1UEAxMMY2EuaHB0cjIy\nLmlvMB4XDTIxMDUyMDEwNDQxMloXDTMxMDUyMDEwNDQxMlowOjEQMA4GA1UEChMH\nQWxjaGVteTEPMA0GA1UECxMGaHB0cjIyMRUwEwYDVQQDEwxjYS5ocHRyMjIuaW8w\nggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDNfrEQHReqizjdvzORZumn\nE6YsJE3NByncHVqK7HgFJIY8Ol9AgO82cWOHIJaBdisP+uOJqFkQRFMxRNWvuXLQ\n7xNrogLabfq4IEPTPzNmOKvs2hAIV3f+e09T1bIQYssCXBUUxqZTWoU2xUTH2ush\ndILM9ZUn61aBTpAW4Ui+rbcj7VRNCMBlQzu23LAqPFiaKQyd3WsiVWJIVVmnZ4jp\n4xnm8k7tWjg28e+6xP5fIK4c/2ASS3Ym6fAdgY9sfeX7AyqD3ucpej9to/bpnxEH\njyAo98bQJ6cO7uyMLYwIxMjCuXiC0hrONFHFDOTrZsis4G2x/u8QvDrOQ9VCZr2Z\nAgMBAAGjIzAhMA8GA1UdEwEB/wQFMAMBAf8wDgYDVR0PAQH/BAQDAgEGMA0GCSqG\nSIb3DQEBCwUAA4IBAQAqQbDxLUCrbIMTUh1CsOymjVRNHkbL5nW4OtutVa5sSs4F\nxOQKxZWGpcyhbkE6a3bM/0LaqU8AQixswGemiYH8/ypVSG6ABI1fdWsr2KP5Pelk\nXTP+8u5wo9Yug1LXPDaEdmJaPFMx74Z5E8KTcEkwcOedD2W/7y7q2kzBIsReRLq4\nubXynpLf84fC3zyEjf2GIx12bFLuGGPKPLgHnNMv+A4kqpxyPx4+fcAi6Mde+R3v\nt8OAtyqbbAiWY9TO4zGdoqvfepN4pv3wAEbO4RxP3p7C9LRViWKFFDfMiZu9Q/pn\nNXZexx+wSkTasDrCYTiNFgqaF1yHz3kQBsmoVZxy\n-----END CERTIFICATE-----\n";
            var sppPass = "Uw>XF=>U>BIR&?lzPPsc3sW".ToSecureString();
            var sppConn = Safeguard.Connect("10.12.224.172", "local", "admin", sppPass, 3, true);
            Console.WriteLine("spp connect ok");

            var joinResponse = sppConn.JoinSPS(spsConn, certChain);
            Console.WriteLine("join finished with response:");
            Console.WriteLine(joinResponse.Body);

            Console.WriteLine("status");
            var statusResponse = spsConn.InvokeMethodFull(Method.Get, "cluster/spp", "{}");
            Console.WriteLine(statusResponse.Body);
        }
    }
}
