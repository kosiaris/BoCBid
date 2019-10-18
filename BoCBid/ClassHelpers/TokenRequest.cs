using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    [Serializable]
    public class TokenRequest
    {
        public string grant_type { set; get; }
        public string client_id { set; get; }
        public string client_secret { set; get; }
        public string scope { set; get; }
    }
}