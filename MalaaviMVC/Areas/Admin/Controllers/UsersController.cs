using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        UnitOfWork context = new UnitOfWork();

        public ActionResult Index()
        {
            var users = context.UserRepository.Get();
            return View(users);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = context.UserRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(context.RoleRepository.Get(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.ActiveCode = Guid.NewGuid().ToString();
                user.RegisterDate = DateTime.Now;
                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                context.UserRepository.Insert(user);
                context.Save();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(context.RoleRepository.Get(), "Id", "Name", user.RoleId);
            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = context.UserRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(context.RoleRepository.Get(), "Id", "Name", user.RoleId);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoleId,UserName,Email,Password,ActiveCode,IsActive,RegisterDate")] User user)
        {
            if (ModelState.IsValid)
            {
                context.UserRepository.Update(user);
                context.Save();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(context.RoleRepository.Get(), "Id", "Name", user.RoleId);
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = context.UserRepository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = context.UserRepository.GetById(id);
            context.UserRepository.Delete(user);
            context.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
