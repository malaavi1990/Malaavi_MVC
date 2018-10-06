using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InsertShowImage;
using KooyWebApp_MVC.Classes;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DomainClasses.Products;

namespace MalaaviMVC.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        UnitOfWork context = new UnitOfWork();

        public ActionResult Index()
        {
            var products = context.ProductRepository.Get();
            return View(products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = context.ProductRepository.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            ViewBag.Category = context.CategoryRepository.Get();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, List<int> selectedCategory, HttpPostedFileBase productImage, string tags)
        {
            if (ModelState.IsValid)
            {
                if (selectedCategory == null)
                {
                    ViewBag.Errorr = true;
                    ViewBag.Category = context.CategoryRepository.Get();
                    return View(product);
                }

                //Insert Category
                foreach (var cate in selectedCategory)
                {
                    context.ProductCategoryRepository.Insert(new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = cate
                    });
                }

                //Insert Image
                product.ImageName = "noPhoto.jpg";
                if (productImage != null && productImage.IsImage())
                {

                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);
                    productImage.SaveAs(Server.MapPath("~/Content/img/Product/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("~/Content/img/Product/" + product.ImageName),
                        Server.MapPath("~/Content/img/Product/Thumb/" + product.ImageName));
                }

                //Insert Tag
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tag = tags.Split(',');
                    foreach (string t in tag)
                    {
                        context.ProductTagRepository.Insert(new ProductTag()
                        {
                            ProductId = product.Id,
                            Tag = t.Trim()
                        });
                    }
                }

                product.Date = DateTime.Now;
                context.ProductRepository.Insert(product);
                context.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Category = context.CategoryRepository.Get();
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = context.ProductRepository.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.SelectedCategory = product.ProductCategories.ToList();
            ViewBag.Category = context.CategoryRepository.Get();
            ViewBag.Tags = string.Join(",", product.ProductTags.Select(t => t.Tag).ToList());
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, List<int> selectedCategory, HttpPostedFileBase productImage, string tags)
        {
            if (ModelState.IsValid)
            {
                //Update Image
                if (productImage != null && productImage.IsImage())
                {
                    if (product.ImageName != "noPhoto.jpg")
                    {
                        System.IO.File.Delete(Server.MapPath("~/Content/img/Product/" + product.ImageName));
                        System.IO.File.Delete(Server.MapPath("~/Content/img/Product/Thumb/" + product.ImageName));
                    }
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(productImage.FileName);
                    productImage.SaveAs(Server.MapPath("~/Content/img/Product/" + product.ImageName));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("~/Content/img/Product/" + product.ImageName),
                        Server.MapPath("~/Content/img/Product/Thumb/" + product.ImageName));
                }
                context.ProductRepository.Update(product);

                //Update Tag
                var tag = context.ProductTagRepository.Get(t => t.ProductId == product.Id);
                foreach (var itemTag in tag)
                {
                    context.ProductTagRepository.Delete(itemTag);
                }
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] tagsSplit = tags.Split(',');
                    foreach (string t in tagsSplit)
                    {
                        context.ProductTagRepository.Insert(new ProductTag()
                        {
                            ProductId = product.Id,
                            Tag = t.Trim()
                        });
                    }
                }

                //Update Category
                var categories = context.ProductCategoryRepository.Get(c => c.ProductId == product.Id);
                foreach (var itemCategory in categories)
                {
                    context.ProductCategoryRepository.Delete(itemCategory);
                }
                foreach (var cate in selectedCategory)
                {
                    context.ProductCategoryRepository.Insert(new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = cate
                    });
                }

                context.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SelectedCategory = selectedCategory;
            ViewBag.Category = context.CategoryRepository.Get();
            ViewBag.Tags = tags;
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = context.ProductRepository.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = context.ProductGalleryRepository.GetById(id);
            context.ProductRepository.Delete(product);

            //System.IO.File.Delete(Server.MapPath("~/Content/img/Product/" + product.ImageName));
            //System.IO.File.Delete(Server.MapPath("~/Content/img/Product/Thumb/" + product.ImageName));

            context.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Gallery(int id)
        {
            ViewBag.Galleries = context.ProductGalleryRepository.Get(g => g.ProductId == id);
            return View(new ProductGallery()
            {
                ProductId = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gallery(ProductGallery productGallery, HttpPostedFileBase imgUpdate)
        {
            //if (ModelState.IsValid)
            //{
            if (imgUpdate != null && imgUpdate.IsImage())
            {
                productGallery.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgUpdate.FileName);
                imgUpdate.SaveAs(Server.MapPath("~/Content/img/Product/" + productGallery.ImageName));
                ImageResizer img = new ImageResizer();
                img.Resize(Server.MapPath("~/Content/img/Product/" + productGallery.ImageName),
                    Server.MapPath("~/Content/img/Product/Thumb/" + productGallery.ImageName));

                context.ProductGalleryRepository.Insert(productGallery);
                context.Save();
            }
            //}
            //ViewBag.Galleries = context.ProductGalleryRepository.Get(g => g.ProductId == id);
            return RedirectToAction("Gallery", new { id = productGallery.ProductId });
        }

        public ActionResult DeleteGallery(int id)
        {
            var gallery = context.ProductGalleryRepository.GetById(id);
            context.ProductGalleryRepository.Delete(gallery);

            System.IO.File.Delete(Server.MapPath("~/Content/img/Product/" + gallery.ImageName));
            System.IO.File.Delete(Server.MapPath("~/Content/img/Product/Thumb/" + gallery.ImageName));

            context.Save();
            return RedirectToAction("Gallery", new { id = gallery.ProductId });
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
