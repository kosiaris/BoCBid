using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoCBid.Models
{
    public class Products
    {
        public int Id { set; get; }

        public byte[] Image { set; get; }

        public string ItemName { set; get; }

        public string Description { set; get; }

        public decimal StartingPrice { set; get; }

        public decimal LastBidPrice { set; get; }

        public int StatusId { set; get; }
        public virtual Status Status { set; get; }

        [Display(Name = "Biding")]
        public DateTime StartBidOn { set; get; }

        public DateTime EndOfBidOn { set; get; }

        public string PhotoUrl { set; get; }

    }
}