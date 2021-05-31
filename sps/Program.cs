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
            var pass = new SecureString();
            pass.AppendChar('a');
            var asd = SafeguardForPrivilegedSessions.Connect("10.12.224.172", "admin", pass, true);
            var result = asd.InvokeMethodFull(Method.Get, "setup");
            Console.Write("1\n");
            Console.Write(result.Body);
            Console.Write("2\n");
            Console.Write(result.StatusCode);
            Console.Write("3\n");
        }
    }
}
