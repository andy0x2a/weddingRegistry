using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace weddingRegistryChecker.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        // GET: Home
        /// <summary>
        /// Home controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {


            ViewBag.Title = "Home Page";
            return View();
        }
    }
}