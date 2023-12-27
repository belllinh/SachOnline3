using SachOnline3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline3.Controllers
{
    public class UserController : Controller
    {
        Model1 db = new Model1();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];

            if (string.IsNullOrEmpty(sTenDN))
                ViewData["Err1"] = "Bạn chưa nhập tên đăng nhập";
            else if (String.IsNullOrEmpty(sMatKhau))
                ViewData["Err2"] = "Phải nhập một mật khẩu";
            else
            {
                KHACHHANG kh = db.KHACHHANG.SingleOrDefault(n => n.Taikhoan == sTenDN && n.Matkhau == sMatKhau);

                if (kh != null)
                {
                    ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    return RedirectToAction("Index","BANSACH");
                }
                else
                    ViewData["Err3"] = "Tên đăng nhập hoặc mật khẩu không đúng";
            }

            return View();
        }

        [HttpGet]
         public ActionResult DangKy ()
        {
            return View();
        }
        public ActionResult DangKy (FormCollection collection, KHACHHANG kh)
        {

            var sHoTen = collection["HoTen"];
            var sTenDN = collection["TenDN"];
            var sMatKhau = collection["MatKhau"];
            var sMatKhauNhapLai = collection["MatKhauNL"];
            var sEmail = collection["Email"];
            var sDienThoai = collection["DienThoai"];
            var sDiaChi = collection["DiaChi"];
            var dNgaySinh = String.Format("{0:MM/dd.yyyy}", collection["NgaySinh"]);
            if (string.IsNullOrEmpty(sHoTen))
            {
                ViewData["err1"] = "Họ Tên không được rỗng";
            }
            else if (string.IsNullOrEmpty(sTenDN))
            {
                ViewData["err2"] = "Tên Đăng Nhập  không được rỗng";
            }
            else if (string.IsNullOrEmpty(sMatKhau))
            {
                ViewData["err3"] = "Nhập lại mật khẩu ";
            }
            else if (string.IsNullOrEmpty(sMatKhauNhapLai))
            {
                ViewData["err4"] = "Mật khẩu nhập lại không khớp";
            }
            else if (string.IsNullOrEmpty(sEmail))
            {
                ViewData["err5"] = "Email không được rỗng ";
            }
            else if (string.IsNullOrEmpty(sDienThoai))
            {
                ViewData["err6"] = "Số điện thoại  không được rỗng";
            }
            else if (db.KHACHHANG.SingleOrDefault(n => n.Taikhoan == sTenDN) != null)
            {
                ViewBag.Thongbao = "Tên đăng nhập đã tồn tại ";
            }
            else if (db.KHACHHANG.SingleOrDefault(n => n.Email == sEmail) != null)
            {
                ViewBag.Thongbao = "Email không được sử dụng  ";
            }
            else
            {
                kh.HoTen = sHoTen;
                kh.Taikhoan = sTenDN;
                kh.Matkhau = sMatKhau;
                kh.Email = sEmail;
                kh.DienthoaiKH = sDienThoai;
                kh.DiachiKH = sDiaChi;
                kh.Ngaysinh = DateTime.Parse(dNgaySinh);
                db.KHACHHANG.Add(kh);
                db.SaveChanges();
                return RedirectToAction("DangNhap");

            }
            return this.DangKy ();
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return Redirect("~/");
        }


        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }

    }
}