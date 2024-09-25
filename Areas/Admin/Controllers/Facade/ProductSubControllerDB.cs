using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductSubControllerDB
    {
        private ApplicationDbContext db;
        public ProductSubControllerDB (ApplicationDbContext db)
        { 
            this.db = db;
        }
        public IEnumerable<Product> getProducts()
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            return items;
        }
        public void AddProduct(Product model)
        {
            db.Products.Add(model);
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public Product getProductByID (int id)
        {
            return db.Products.Find(id);
        }
        public void AttachProduct(Product model)
        {
            db.Products.Attach(model);
        }
        public void EntryProduct(Product model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
        }
        public void RemoveProduct(Product model)
        {
            db.Products.Remove(model);
        }
    }
}