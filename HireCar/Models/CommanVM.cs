using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class CommanVM
    {
       
        public int statusCode { get; set; }
        public string message { get; set; }
        public string version { get; set; }
        public List<UserResponseVM> data { get; set; }
        public bool Success { get; set; }

    }
}