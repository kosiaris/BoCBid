using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class GePayment
    {
        public string authCodeNeeded { set; get; }
        public virtual payment payment { set;get;}
    }
}