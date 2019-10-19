using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class InfoRecords
    {
        public string help { set; get; }
        public string success { set; get; }
        public string limit { set; get; }

        //[JsonProperty("result")]
        //public List<result> result { get; set; }
        //[JsonProperty("records")]
        public Records records { set; get; }
    }
}