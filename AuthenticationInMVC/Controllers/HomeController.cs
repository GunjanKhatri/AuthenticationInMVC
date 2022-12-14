using AuthenticationInMVC.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationInMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [CustomAuthorizeAttribute(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles="Admin,Editor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}