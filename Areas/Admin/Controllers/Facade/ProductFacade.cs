using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.ProductControllerFacade
{
    public class ProductFacade
    {
        ProductSubControllerDB pscdDB;
        public ProductFacade(ApplicationDbContext db)
        {
            pscdDB = new ProductSubControllerDB(db);
        }
        public IEnumerable<Product> getProducts()
        {
            return pscdDB.getProducts();
        }
        public void AddProduct(Product model)
        {
            pscdDB.AddProduct(model);
        }
        public void SaveChanges()
        {
            pscdDB.SaveChanges();
        }
        public Product getProductByID(int id)
        {
            return pscdDB.getProductByID(id);
        }
        public void AttachProduct(Product model)
        {
            pscdDB.AttachProduct(model);
        }
        public void EntryProduct(Product model)
        {
            pscdDB.EntryProduct(model);
        }
        public void RemoveProduct(Product model)
        {
            pscdDB.RemoveProduct(model);
        }
    }
}