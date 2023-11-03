using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class OwnerController : Controller
       { 
        public ActionResult Index()
        {
          return View();
        }
        public ActionResult CarType()
        {
            return View();
        }
        public  ActionResult CarDetails()
        {
            return View();
        }
      
    }
}