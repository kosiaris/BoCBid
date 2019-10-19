using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoCBid.Models
{
    public class SetBid
    {
        public int Id { set; get; }
        
        public string Account { set; get; }

        public int ProductsId { set; get; }
        public virtual Products Products { set; get; }

        [Display(Name = "Make An Offer")]
        public decimal? MakeAnOffer { set; get; }

        [Display(Name = "Make a Bid")]
        public decimal OfferBitPrice { set; get; }

        public string ApplicationUserId { set; get; }
        public virtual ApplicationUser ApplicationUser { set; get; }
    }
}