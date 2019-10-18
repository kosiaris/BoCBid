using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoCBid.ClassHelpers
{
    public class AccountsResponse
    {
        public string BankId { set; get; }
        public string AccountId { set; get; }
        public string AccountAlias { set; get; }
        public string AccountType { set; get; }
        public string AccountName { set; get; }
        public string IBAN { set; get; }
        public string Currency { set; get; }
        public string InfoTimeStamp { set; get; }
        public string InterestRate { set; get; }
        public string MaturityDate { set; get; }
        public string LastPaymentDate { set; get; }
        public string NextPaymentDate { set; get; }
        public string RemainingInstallments { set; get; }
        public List<Balances> Balances { set; get; }
    }
}