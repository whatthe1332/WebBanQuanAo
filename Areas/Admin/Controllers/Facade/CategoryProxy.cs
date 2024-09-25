using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Facade
{
    public interface ICategoryFacade
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category model);
        void SaveChanges();
        Category GetCategoryById(int id);
        void AttachCategory(Category model);
        void EntryCategory(Category model);
        void RemoveCategory(Category model);
    }
    public class CategoryProxy : ICategoryFacade
    {
        private readonly ICategoryFacade categoryFacade;
        private readonly UserManager<ApplicationUser> userManager;

        public CategoryProxy(ICategoryFacade categoryFacade, UserManager<ApplicationUser> userManager)
        {
            this.categoryFacade = categoryFacade;
            this.userManager = userManager;
        }

        public IEnumerable<Category> GetCategories()
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin")) 
            {
                return categoryFacade.GetCategories();
            }
            else
            {
                return Enumerable.Empty<Category>();
            }
        }

        public void AddCategory(Category model)
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                categoryFacade.AddCategory(model);
            }
            else
            {
            }
        }

        public void SaveChanges()
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                categoryFacade.SaveChanges();
            }
            else
            {
            }
        }

        public Category GetCategoryById(int id)
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                return categoryFacade.GetCategoryById(id);
            }
            else
            {
                return null;
            }
        }

        public void AttachCategory(Category model)
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                categoryFacade.AttachCategory(model);
            }
            else
            {
            }
        }

        public void EntryCategory(Category model)
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                categoryFacade.EntryCategory(model);
            }
            else
            {
            }
        }

        public void RemoveCategory(Category model)
        {
            if (userManager.IsInRole(userManager.FindByNameAsync("admin").Result.Id, "Admin"))
            {
                categoryFacade.RemoveCategory(model);
            }
            else
            {

            }
        }
    }
}