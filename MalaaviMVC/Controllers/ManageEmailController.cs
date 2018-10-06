using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MalaaviMVC.Controllers
{
    public class ManageEmailController : Controller
    {
        public ActionResult ActivationEmail()
        {
            return PartialView();
        }

        public ActionResult ForgotPasswordEmail()
        {
            return PartialView();
        }
    }
}