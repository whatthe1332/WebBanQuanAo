using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductCategoryFacade
    {
        ProductCategorySubControllerDB pcsdDB;

        public ProductCategoryFacade(ApplicationDbContext db)
        {
            pcsdDB = new ProductCategorySubControllerDB(db);
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return pcsdDB.GetProductCategories();
        }

        public void AddProductCategory(ProductCategory model)
        {
            pcsdDB.AddProductCategory(model);
        }

        public void SaveChanges()
        {
            pcsdDB.SaveChanges();
        }

        public ProductCategory GetProductCategoryByID(int id)
        {
            return pcsdDB.GetProductCategoryByID(id);
        }

        public void AttachProductCategory(ProductCategory model)
        {
            pcsdDB.AttachProductCategory(model);
        }

        public void EntryProductCategory(ProductCategory model)
        {
            pcsdDB.EntryProductCategory(model);
        }

        public void RemoveProductCategory(ProductCategory model)
        {
            pcsdDB.RemoveProductCategory(model);
        }
    }
}