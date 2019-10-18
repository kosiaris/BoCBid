using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class AuthorizeResponse
    {
        public string Response_type { set; get; }
        public string Redirect_uri { set; get; }
        public string State { set; get; }
        public string Scope { set; get; }
        public string Subscriptionid { set; get; }
    }
}