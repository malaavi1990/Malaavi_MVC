using System.Web.Mvc;
using System.Web.Security;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_ViewModels;

namespace MalaaviMVC.Areas.UserPanel.Controllers
{
    public class AccountController : Controller
    {
        UnitOfWork context = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (ModelState.IsValid)
            {
                var user = context.UserRepository.GetUserByUserName(User.Identity.Name);
                string oldPasswordHash =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(change.OldPassword, "Md5");
                if (user.Password == oldPasswordHash)
                {
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(change.Password, "MD5");
                    context.Save();
                    ViewBag.Success = true;
                }
                else
                {
                    ModelState.AddModelError("oldPassword", "کلمه عبور فعلی صحیح نمی باشد");
                }
            }
            return View();
        }
    }
}