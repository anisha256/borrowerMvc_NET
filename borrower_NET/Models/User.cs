using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace borrower_NET.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Pincode { get; set; }
    }
}