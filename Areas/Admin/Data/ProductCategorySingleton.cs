using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;
namespace WebBanHangOnline.Areas.Admin.Data
{
    public sealed class ProductCategorySingleton
    {
        public static ProductCategorySingleton Instance { get; } = new ProductCategorySingleton();
        public List<ProductCategory> listProductCategory { get; } = new List<ProductCategory>();

        private ProductCategorySingleton() { }
        
        //only one time
        public void Init(ApplicationDbContext db)
        {
            if (listProductCategory.Count == 0)
            {
                var items = db.ProductCategories;
                foreach (var item in items)
                {
                    listProductCategory.Add(item);
                }
            }
        }
    }
}