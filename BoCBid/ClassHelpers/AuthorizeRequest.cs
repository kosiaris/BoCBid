using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class AuthorizeRequest
    {
        //      curl --request GET \
        //--url 'https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/oauth2/authorize?response_type=REPLACE_THIS_VALUE&redirect_uri=REPLACE_THIS_VALUE&state=REPLACE_THIS_VALUE&scope=REPLACE_THIS_VALUE&subscriptionid=REPLACE_THIS_VALUE' \
        //--header 'accept: text/html'

        public string client_id { set; get; }
        public string scope { set; get; }
        public string resource_owner { set; get; } //resource-owner
        public string redirect_uri { set; get; }
        public string original_url { set; get; } //original-url
        public string dp_state { set; get; } //dp-state
        public string dp_data { set; get; } //dp-data

    }

}