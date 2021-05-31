using System;
using OneIdentity.SafeguardDotNet;

namespace sps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var asd = new SafeguardSessionsConnection("10.12.224.172");
            var result = asd.InvokeMethodFull(Method.Get, "setup");
            Console.Write("aaaaaa");
            Console.Write(result.Body);
        }
    }
}
