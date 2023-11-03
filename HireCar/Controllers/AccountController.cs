using HireCar.ImageConverter;
using HireCar.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class AccountController : Controller
    {

        Base64Converter _base64;
        public AccountController()
        {

            _base64 = new Base64Converter();
        }

        public ActionResult Login()
        {
            return View();
        } 

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(UserResponseVM userResponseVM ,HttpPostedFileBase profileImg)
        {
            try
            {
                string TheFileName = Path.GetFileName(profileImg.FileName);
                userResponseVM.FileName = TheFileName;
                userResponseVM.ProfileImage = _base64.ImgToBase64(profileImg);
                if (ModelState.IsValid)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = "https://localhost:44347/";
                        var url = "AddEditUser";
                        webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                        string data = JsonConvert.SerializeObject(userResponseVM);
                        var response = webClient.UploadString(url, data);
                        var result = JsonConvert.DeserializeObject<LoginResponseVM>(response);
                    }             
                    ViewBag.ConfirmationMessage = "Registration successful";
                    ModelState.Clear();
                }
                else
                {
                    return View(userResponseVM);
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ViewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            try
               {
               using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress ="https://localhost:44347/";
                    var url = "login";
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(loginVM);
                    var response = webClient.UploadString(url, data);
                    var result = JsonConvert.DeserializeObject<LoginResponseVM>(response);
                   
                    if (result.statusCode == 200)
                    {
                          
                        if (result.data.UserType.Equals("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            if (result.data.UserType.Equals("Owner"))
                            {
                                Session["id"] = result.data.Id;
                              
                                return RedirectToAction("Index", "Owner");
                            }

                            else
                            {
                                if (result.data.UserType.Equals("client"))
                                {
                                    return RedirectToAction("Index", "Client");
                                }
                                else
                                {

                                }
                            }

                        }
                    }

                }
    
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return View();
           
        }

    }
}