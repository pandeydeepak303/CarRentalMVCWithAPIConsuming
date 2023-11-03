using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class HiringVM
    {
        public int CarOwnerId { get; set; }
        public DateTime DateOfHiring { get; set; }
        public int UserId { get; set; }
        public double TotalKm { get; set; }
        public object Name { get; set; }
        public object Gender { get; set; }
        public object ContectNumber { get; set; }
        public object Email { get; set; }
        public object ProfileImage { get; set; }
        public object Address { get; set; }

    }

    public class roottest
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object Message { get; set; }
        public string version { get; set; }
        public List<HiringVM> data { get; set; }
        public bool Success { get; set; }


    }



}