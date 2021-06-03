using System;
using System.Collections.Generic;
using System.Linq;
using OneIdentity.SafeguardDotNet.Authentication;
using OneIdentity.SafeguardDotNet.Event;
using RestSharp;
using Serilog;

namespace OneIdentity.SafeguardDotNet
{
    internal class SpsClusterRequest
    {
        public bool enabled { get; set; }
        public string listen_address { get; set; }
    };
}