using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace borrower_NET.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Pincode { get; set; }
    }
}