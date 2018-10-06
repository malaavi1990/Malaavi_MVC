using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DataLayer.Services;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slider()
        {
            return PartialView();
        }
    }
}