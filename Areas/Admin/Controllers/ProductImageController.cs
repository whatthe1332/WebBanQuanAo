using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly ProductImageFacade productImageFacade;

        public ProductImageController()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            productImageFacade = new ProductImageFacade(db);
        }

        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = productImageFacade.GetProductImages(id);
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            productImageFacade.AddProductImage(productId, url);
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            productImageFacade.RemoveProductImage(id);
            return Json(new { success = true });
        }
    }
}