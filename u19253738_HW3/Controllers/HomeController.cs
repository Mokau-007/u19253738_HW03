using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //This library needs to be stated so that the program can read and write Input and outbut

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
            

            //The if statement is used to assess the type file type option selected so that the file uploaded can be stored in the relevant folder
            if (FileType == "Document")
            {
                if (files != null & files.ContentLength > 0)
                {
                    //List of file extention type that the user can upload
                    var fileExtention = new [] { "txt", "doc", "docx", "pdf", "xls", "xlsx", "ppt"};
                    var fileName = Path.GetFileName(files.FileName);
                    string fileExt = fileName.Substring(fileName.IndexOf('.') + 1);
                    //Validates the file extention of the file uploaded before uploading
                    if (fileExtention.Contains(fileExt))
                    {
                        // store the file inside ~/Media/Documents folder

                        var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                        // The chosen default path for saving

                        files.SaveAs(path);
                    }
                    else
                    {
                        TempData["FileError"] = "Please insert right file type";
                    }
                   
                }
                else
                {
                    TempData["NoFile"] = "Please select file to upload";
                }
            }
            //The if statement is used to assess the type file type option selected so that the file uploaded can be stored in the relevant folder
            if (FileType == "Image")
            {
                if (files != null & files.ContentLength > 0)
                {

                    //List of file extention type that the user can upload
                    var fileExtention = new[] { "jpg", "jpeg", "png" };
                    var fileName = Path.GetFileName(files.FileName);
                    string fileExt = fileName.Substring(fileName.IndexOf('.') + 1);
                    //Validates the file extention of the file uploaded before uploading
                    if (fileExtention.Contains(fileExt))
                    {
                        // store the file inside ~/Media/Documents folder

                        var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);

                        // The chosen default path for saving

                        files.SaveAs(path);
                    }
                    else
                    {
                        TempData["FileError"] = "Please insert right file type";
                    }

                }
            }
            //The if statement is used to assess the type file type option selected so that the file uploaded can be stored in the relevant folder
            if (FileType == "Video")
            {
                if (files != null & files.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(files.FileName);

                    // store the file inside ~/Media/Documents folder

                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);

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