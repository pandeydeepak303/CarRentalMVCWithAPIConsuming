using HireCar.ImageConverter;
using HireCar.Models;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;



namespace HireCar.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : Controller
    {


        Base64Converter _base64;
        public AdminController()
        {

            _base64 = new Base64Converter();
        }
        public ActionResult Index()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var json = webClient.DownloadString("GetUser");
                    var userResponse = JsonConvert.DeserializeObject<CommanVM>(json);

                    int totalOwnerRegister = userResponse.data.Where(x => x.UserType == "Owner").Count();
                    ViewBag.TotalOwnerRegister = totalOwnerRegister;

                    int totalClientRegister = userResponse.data.Where(x => x.UserType == "Client").Count();
                    ViewBag.TotalClientRegister = totalClientRegister;
                    GetTotalCar();

                    ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
                    return View(userResponse);
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public ActionResult GetTotalCar()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var json = webClient.DownloadString("GetAllCarDetailsType");
                    var userResponse = JsonConvert.DeserializeObject<CommanTest>(json);
                    Ride();

                    if (userResponse != null)
                    {
                        int totalCars = userResponse.data.Count();
                        ViewBag.totalCar = totalCars;
                    }
                    else
                    {
                        ViewBag.totalCar = 0;
                    }

                    return View();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public ActionResult Ride()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var json = webClient.DownloadString("GetCarHiring");
                    var userResponse = JsonConvert.DeserializeObject<roottest>(json);
                    if (userResponse != null && userResponse.data != null)
                    {
                        int totalRide = userResponse.data.Count();
                        ViewBag.totalRide = totalRide;
                    }
                    else
                    {
                        ViewBag.totalKm = 0;
                    }

                    return View();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
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
                      
                        var user = userData.data.FirstOrDefault(x => x.Id == id);
                        if (user != null)
                        {
                            return View(user);
                        }
                    }
                   
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (WebException ex)
            {
               
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserVm userVm  , HttpPostedFileBase profileImg)
        {
            try
            {
                string TheFileName = Path.GetFileName(profileImg.FileName);
                userVm.FileName = TheFileName;
                userVm.ProfileImage = _base64.ImgToBase64(profileImg);
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var url = "AddEditUser";
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(userVm);
                    var response = webClient.UploadString(url, data);
                    var result = JsonConvert.DeserializeObject<LoginResponseVM>(response);

                   
                    TempData["SuccessMessage"] = "Data updated successfully.";

                    
                    return RedirectToAction("Index", "Admin");
                }
            }
            catch (WebException ex)
            {
              
                throw ex;
            }
        }
    
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44347/";

                try
                {
                    string apiUrl = "api/User/DeleteUser/" + id;
                    string jsonResponse = webClient.DownloadString(apiUrl);
                    var userData = JsonConvert.DeserializeObject<servicesresponce<List<UserVm>>>(jsonResponse);

                    if (userData.statusCode == 200)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = userData.message;
                    }
                }
                catch (WebException ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult View(int? id)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44347/";
                    var json = webClient.DownloadString("GetUser");
                    var userResponse = JsonConvert.DeserializeObject<servicesresponce<List<UserVm>>>(json);

                    if (userResponse != null && userResponse.data != null)
                    {
                        var userdata = userResponse.data.FirstOrDefault(x => x.Id == id);
                        return View(userdata);
                    }
                    else
                    {
                        
                        return View("NotFound");
                    }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }


        public ActionResult AddCarType()
        {
            return View(); 
        }






    }


}
