using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        UnitOfWork context = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListCategory()
        {
            var categories = context.CategoryRepository.Get();
            return PartialView(categories);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.CategoryRepository.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Create(int? id)
        {
            return PartialView(new Category()
            {
                ParentId = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,ParentId")] Category category)
            {
            if (ModelState.IsValid)
            {
                
                context.CategoryRepository.Insert(category);
                context.Save();
                return PartialView("ListCategory", context.CategoryRepository.Get());
            }

            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.CategoryRepository.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                context.CategoryRepository.Update(category);
                context.Save();
                return PartialView("ListCategory", context.CategoryRepository.Get());
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = context.CategoryRepository.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return PartialView(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = context.CategoryRepository.GetById(id);
            IEnumerable<Category> subCategories = context.CategoryRepository.Get(s => s.ParentId == category.Id);
            if (subCategories != null)
            {
                foreach (var item in subCategories)
                {
                    context.CategoryRepository.Delete(item);
                }
            }
            context.CategoryRepository.Delete(category);
            context.Save();
            return PartialView("ListCategory", context.CategoryRepository.Get());
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
