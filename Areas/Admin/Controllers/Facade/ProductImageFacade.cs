using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductImageFacade
    {
        private readonly ProductImageSubControllerDB piscdDB;

        public ProductImageFacade(ApplicationDbContext db)
        {
            piscdDB = new ProductImageSubControllerDB(db);
        }

        public IEnumerable<ProductImage> GetProductImages(int productId)
        {
            return piscdDB.GetProductImages(productId);
        }

        public void AddProductImage(int productId, string url)
        {
            piscdDB.AddProductImage(productId, url);
        }

        public void RemoveProductImage(int id)
        {
            piscdDB.RemoveProductImage(id);
        }
    }
}