using HireCar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class ClientController : Controller
    {
        //GET: Client
        public ActionResult Index()
        {

            return View();
        }

         public ActionResult AllUsers()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var json = webClient.DownloadString("GetUser");
                    var userData = JsonConvert.DeserializeObject<servicesresponce<List<UserVm>>>(json);

                    if (userData != null && userData.data != null)
                    {
                        var user = userData.data.Where(x => x.IsDeleted== false);
                        if (user != null)
                        {
                            return View(user);
                        }
                    }

                    return RedirectToAction("AllUsers", "Client");
                }
            }
            catch (WebException ex)
            {

                throw ex;
            }        
        }







    }
}