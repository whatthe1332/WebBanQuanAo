using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade;
using WebBanHangOnline.Areas.Admin.Data;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductCategoryController : ControllerTemplateMethod
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly ILogger<ProductCategoryController> _logger;
        private ProductCategoryFacade productCategoryFacade;
        private readonly ProductCategorySingleton productCategorySingleton;

        public ProductCategoryController()
        {
            productCategoryFacade = new ProductCategoryFacade(db);
            productCategorySingleton = ProductCategorySingleton.Instance;
            productCategorySingleton.Init(db);
        }
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            //var items = productCategorySingleton.listProductCategory;
            var items = productCategoryFacade.GetProductCategories();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                productCategorySingleton.listProductCategory.Add(model);
                db.ProductCategories.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = productCategoryFacade.GetProductCategoryByID(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
                productCategoryFacade.AttachProductCategory(model);
                productCategoryFacade.EntryProductCategory(model);
                productCategoryFacade.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var categoryToDelete = productCategoryFacade.GetProductCategoryByID(id);
            if (categoryToDelete != null)
            {
                var productsToDelete = db.Products.Where(p => p.ProductCategoryId == categoryToDelete.Id).ToList();
                ITerator iterator = new ProductIterator(productsToDelete);

                while (!iterator.IsDone)
                {
                    var currentProduct = iterator.CurrentItem;
                    var productImagesToDelete = db.ProductImages.Where(img => img.ProductId == currentProduct.Id) .ToList();
                    foreach (var img in productImagesToDelete)
                    {
                        db.ProductImages.Remove(img);
                    }
                    iterator.Next(); 
                }
                db.ProductCategories.Remove(categoryToDelete);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        protected override void PrintRoutes()
        {
            _logger.LogInformation("=============");
        }

        protected override void PrintDIs()
        {
            _logger.LogInformation("======1234=======");
        }
    }
}