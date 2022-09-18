using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace borrower_NET.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public int FundAmount { get; set; }
        public string FundPurpose { get; set; }
        public string BusinessType { get; set; }
    }
}