using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u19253738_HW3.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase files)
        {
            
            if (FileType == "Document")
            {
                if(files != null & files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Documents"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
            }
            if (FileType == "Document")
            {
                if (files != null & files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Documents"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
            }
            if (FileType == "Image")
            {
                if (files != null & files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Images"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                    
                }
            }
            if (FileType == "Videos")
            {
                if (files != null & files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/App_Data/Media/Videos"), fileName);

                    // The chosen default path for saving

                    files.SaveAs(path);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
           
            return View();
        }

        
    }
}