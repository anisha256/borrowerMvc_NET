using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace borrower_NET.Models
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public int FundAmount { get; set; }

        [Required]
        public string FundPurpose { get; set; }

        [Required]
        public string BusinessType { get; set; }
    }
}