using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class CarTypeVM
    {
        public int Type_Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string YearOfModel { get; set; }
        public string Capacity { get; set; }
        public string  CarImage { get; set; }
        public object IsDeleted { get; set; }
    }
    public class CommanTest
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object Message { get; set; }
        public string version { get; set; }
        public List<CarTypeVM> data { get; set; }
        public bool Success { get; set; }

    }

  
}