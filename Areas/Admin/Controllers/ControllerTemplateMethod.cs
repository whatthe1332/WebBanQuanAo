using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public abstract class ControllerTemplateMethod : Controller 
    {
        protected abstract void PrintRoutes();
        protected abstract void PrintDIs();
        public void PrintInformation()
        {
            PrintRoutes();
            PrintDIs();
        }
    }
}