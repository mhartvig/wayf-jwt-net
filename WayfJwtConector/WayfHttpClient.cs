using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;

namespace WayfJwtConector
{
    public class WayfHttpClientFactory
    {
        public HttpClient Client { get; set; }
        public WayfHttpClientFactory(HttpClient client)
        {
            Client = client;
        }
    }
}
