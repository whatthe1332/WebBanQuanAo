using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Facade
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly ApplicationDbContext db;

        public CategoryFacade(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories;
        }

        public void AddCategory(Category model)
        {
            db.Categories.Add(model);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Find(id);
        }

        public void AttachCategory(Category model)
        {
            db.Categories.Attach(model);
        }

        public void EntryCategory(Category model)
        {
            db.Entry(model).State = EntityState.Modified;
        }

        public void RemoveCategory(Category model)
        {
            db.Categories.Remove(model);
        }

    }
}