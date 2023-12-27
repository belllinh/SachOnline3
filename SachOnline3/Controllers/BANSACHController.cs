using SachOnline3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace SachOnline3.Controllers
{
    public class BANSACHController : Controller
    {
        Model1 db = new Model1();

        // GET: BANSACH

        public List<SACH> laysachmoi(int count)
        {
            return db.SACH.OrderByDescending(n => n.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page )
        {
            int pageSize = 5;
            int pageNum  = (page ?? 1);
            var dssach = laysachmoi(6);
            return View(dssach.ToPagedList(pageNum,pageSize));
        }
        
        public ActionResult NavbarPartial()
        {
            return PartialView();
        }
        public ActionResult SliderPartial()
        {
            return PartialView();
        }
        public ActionResult Sachtheochude(int id, int ?page)
        {
            ViewBag.MaCD = id;

            int iSize = 3; 
            int iPagaNum = (page ?? 1);
            var sach = from s in db.SACH where s.MaCD == id select s;
            return View(sach.ToPagedList(iPagaNum, iSize));
        }
        public ActionResult SachtheoNXB(int ID)
        {
            var SACH = from S in db.SACH where S.MaNXB == ID select S;
            return View(SACH);
        }
        public ActionResult ChuDePartial()
        {
            var listChuDe = from cd in db.CHUDE select cd;
            return PartialView(listChuDe);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNXB = from CD in db.NHAXUATBAN select CD;
            return PartialView(listNXB);

        }
        public ActionResult SachBanNhieu()
        {
            var dssach = laysachmoi(6);
            return PartialView(dssach);
        }

        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in db.SACH where s.Masach == id select s;
            return View(sach.Single());

        }
        

    }
}

