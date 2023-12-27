using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using SachOnline3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline3.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        Model1 db = new Model1();
        public ActionResult Index()
        {
            //if (Session["Admin"]== null)
            //    return RedirectToAction("Login");
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login (FormCollection f )
        {
            string UserName = f["UserName"];
            string Password = f["Password"];
            var admin = db.Admin.FirstOrDefault(x=>x.Username==UserName && x.Password == Password);
                if(admin != null )
            {
                Session["Admin"]= admin;
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.ThongBao = "Sai UserName va Password";
            }
            return View();
        }
        //public ActionResult MenuPartial()
        //{
        //    var path = Server.MapPath("~/Areas/Navigation/Navigation.json");
        //    var content = System.IO.File.ReadAllText(path);
        //    var menu = JsonConvert.DeserializeObject<NavigationMenu>(content);
        //    return PartialView(menu);
        //}
    }
    }
