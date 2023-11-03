using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class Data
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
    }
    public class LoginResponseVM
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string version { get; set; }
        public Data data { get; set; }
        public bool Success { get; set; }
    }
}