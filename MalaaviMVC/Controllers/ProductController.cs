using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalaaviMVC_DataLayer.Context;

namespace MalaaviMVC.Controllers
{
    public class ProductController : Controller
    {
        UnitOfWork context=new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowCategory()
        {
            var category = context.CategoryRepository.Get();
            return PartialView(category);
        }
    }
}