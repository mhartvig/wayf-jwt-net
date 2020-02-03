using System;
using System.Collections.Generic;
using System.Text;

namespace WayfJwtConnector
{
    public class WayfOptions
    {
        public string WayfPublicKey { get; set; }
        public string Endpoint { get; set; }
        public string Issuer { get; set; }
        public string Acs { get; set; }
    }
}
