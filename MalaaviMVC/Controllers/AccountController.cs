using System;
using System.Web.Mvc;
using System.Web.Security;
using MalaaviMVC_Business;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_Utilities.EmailServices;
using MalaaviMVC_ViewModels;

namespace MalaaviMVC.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork _uow = new UnitOfWork();
        IUserServices userService = new UserServices();

        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = userService.InsertUserService(register);
                if (user != null)
                {
                    // Send Active Code To Email
                    string body = PartialToString.RenderPartialView("ManageEmail", "ActivationEmail", user);
                    SendEmail.Send(user.Email, "ایمیل فعالسازی", body);
                    return View("SuccessRegister", user);
                }
                else
                {
                    ModelState.AddModelError("Email", "ایمیل وارد شده قبلا ثبت شده است");
                }
            }
            return View();
        }

        public ActionResult ActiveUser(string id)
        {
            var user = userService.ActiveUserService(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = user.UserName;
            return View();
        }

        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = _uow.UserRepository.GetUserByEmailAndPassword(login.Email, hashPassword);
                if (user != null)
                {
                    if (user.IsActive == true)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "ایمیل شما تایید نشده است");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده موجود نمی باشد");
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var user = _uow.UserRepository.GetUserByEmail(forgot.Email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        string body = PartialToString.RenderPartialView("ManageEmail", "ForgotPasswordEmail", user);
                        SendEmail.Send(forgot.Email, "بازیابی کلمه عبور", body);
                        return View("SuccessForgotPassword", user);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "");
                }
            }

            return View();
        }


        public ActionResult ResetPassword(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(string id, ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var user = _uow.UserRepository.GetUserByActiveCode(id);
                if (user != null)
                {
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(reset.Password, "MD5");
                    user.ActiveCode = Guid.NewGuid().ToString();
                    _uow.Save();
                    return Redirect("/Login?recovery=true");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }
    }
}