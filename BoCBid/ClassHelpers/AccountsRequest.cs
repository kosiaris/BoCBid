using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class AccountsRequest
    {
  //      curl --request GET \
  //--url 'https://sandbox-apis.bankofcyprus.com/df-boc-org-sb/sb/psd2/v1/accounts?client_secret=REPLACE_THIS_VALUE&client_id=REPLACE_THIS_VALUE' \

        public string authorization { set; get; }
        public string correlationid { set; get; }
        public string customerid { set; get; }
        public string journeyid { set; get; }
        public string lang { set; get; }
        public string onlineaccessflag { set; get; }
        public string originchannelid { set; get; }
        public string origindeptid { set; get; }
        public string originemployeeid { set; get; }
        public string originsourceid { set; get; }
        public string originterminalid { set; get; }
        public string originuserid { set; get; }
        public string subscriptionid { set; get; }
        public string timestamp { set; get; }
        public string tppid { set; get; }
    }
}