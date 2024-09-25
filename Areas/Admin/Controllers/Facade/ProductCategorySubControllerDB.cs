using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Areas.Admin.Data;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductCategorySubControllerDB
    {
        private ApplicationDbContext db;
        public ProductCategorySubControllerDB(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return db.ProductCategories.OrderByDescending(x => x.Id);
        }
        public void AddProductCategory(ProductCategory model)
        {
            db.ProductCategories.Add(model);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public ProductCategory GetProductCategoryByID(int id)
        {
            return db.ProductCategories.Find(id);
        }
        public void AttachProductCategory(ProductCategory model)
        {
            db.ProductCategories.Attach(model);
        }
        public void EntryProductCategory(ProductCategory model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
        public void RemoveProductCategory(ProductCategory model)
        {
            db.ProductCategories.Remove(model);
        }
    }
}