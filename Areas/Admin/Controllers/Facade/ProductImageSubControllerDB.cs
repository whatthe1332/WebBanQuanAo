using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductImageSubControllerDB
    {
        private readonly ApplicationDbContext db;
        public ProductImageSubControllerDB(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            return db.ProductImages.Where(x => x.ProductId == productId).ToList();
        }

        public void AddProductImage(int productId, string url)
        {
            db.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
        }

        public void RemoveProductImage(int id)
        {
            var item = db.ProductImages.Find(id);
            if (item != null)
            {
                db.ProductImages.Remove(item);
                db.SaveChanges();
            }
        }
    }
}