using blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace blogs.Controllers
{
    public class AuthController : Controller
    {
      
        // GET: Auth
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                dbContext db = new dbContext();
                var user = db.users.Where(u => u.Email == model.Email && u.Password == model.Password).SingleOrDefault();
                if(user!=null)
                {
                    var idntity = new ClaimsIdentity(new[]{
                        new Claim(ClaimTypes.Name,user.Name),
                         new Claim(ClaimTypes.Email,user.Email),
                         new Claim(ClaimTypes.NameIdentifier,user.id.ToString()),
                         new Claim(ClaimTypes.Role,user.Role),

                    },
                    "ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var authManager = ctx.Authentication;
                    authManager.SignIn(idntity);
                    return Redirect(GetRedirectedUrl(model.ReturnUrl));
                }
                ModelState.AddModelError("", "Invalid Email Or Password");
                return View();
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
       private string GetRedirectedUrl(string returnUrl)
        {
           if(string.IsNullOrEmpty(returnUrl)|| !Url.IsLocalUrl(returnUrl))
           {
               return Url.Action("Index", "Home");
           }
           return returnUrl;
        }
    }
}