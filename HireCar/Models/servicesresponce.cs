using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireCar.Models
{
    public class servicesresponce<T>
    {
       
            public int statusCode { get; set; }
            public string message { get; set; }
            public string version { get; set; }
            public T data { get; set; }
        
    }
}