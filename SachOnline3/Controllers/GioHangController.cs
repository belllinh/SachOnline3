
using Microsoft.Ajax.Utilities;
using SachOnline3;
using SachOnline3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        Model1 db = new Model1();

        public ActionResult Index()
        {
            var userLogin = (KHACHHANG)Session["TaiKhoan"];
            if (userLogin == null)
            {
                return Redirect("/User/DangNhap");
            }
            else
            {
                var GioHang = db.DONDATHANG.FirstOrDefault(d => d.Ngaydat == null && d.MaKH == userLogin.MaKH);
                if (GioHang == null)
                {
                    GioHang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false,
                    };
                    db.DONDATHANG.Add(GioHang);
                    db.SaveChanges();
                }
                var lstCTGioHang = db.CHITIETDONTHANG.Where(ct => ct.MaDonHang == GioHang.MaDonHang).ToList();
                var model = (from ct in lstCTGioHang
                             join s in db.SACH on ct.Masach equals s.Masach
                             select new
                             {
                                 MaDonHang = ct.MaDonHang,
                                 Masach = ct.Masach,
                                 Tensach = s.Tensach,
                                 Mota = s.Mota,
                                 Anhbia = s.Anhbia,
                                 Giaban = s.Giaban,
                                 Soluong = ct.Soluong,
                                 Soluongton = s.Soluongton,
                                 ThanhTien = ct.Soluong * s.Giaban
                             }).Select(t=>t.ToExpando()).ToList();

                return View(model);

            }

        }


        // GET: GioHang


        //Thêm sản phẩm vào giỏ

        public ActionResult ThemGioHang(int MaSach)
        {
            var userLogin = (KHACHHANG)Session["TaiKhoan"];
            if (userLogin == null)
            {
                return Redirect("/User/DangNhap");
            }
            else
            {
                var Giohang = db.DONDATHANG.FirstOrDefault(d => d.Ngaydat == null && d.MaKH == userLogin.MaKH);
                if (Giohang == null)
                {
                    Giohang = new DONDATHANG
                    {
                        MaKH = userLogin.MaKH,
                        Dathanhtoan = false,
                    };
                    db.DONDATHANG.Add(Giohang);
                    db.SaveChanges();
                }

                //Cap nhat CTDonHang
                var CTDonHang = db.CHITIETDONTHANG.FirstOrDefault(
                    ct => ct.Masach == MaSach && ct.MaDonHang == Giohang.MaDonHang
                        );
                if (CTDonHang == null)
                {
                    CTDonHang = new CHITIETDONTHANG
                    {
                        Masach = MaSach,
                        MaDonHang = Giohang.MaDonHang,
                        Soluong = 1,
                    };
                }
                else
                    CTDonHang.Soluong++;
                db.CHITIETDONTHANG.AddOrUpdate(CTDonHang);

                db.SaveChanges();
            }
            return Redirect("index");

        }
        public ActionResult CapNhapGioHang(int MaDonHang, int MaSach, int SoLuong)
        {
            var ct = db.CHITIETDONTHANG.FirstOrDefault(t => t.MaDonHang == MaDonHang && t.Masach == MaSach);
            ct.Soluong = SoLuong;
            if (SoLuong == 0)
            {
                db.CHITIETDONTHANG.Remove(ct);
            }
            else
            {
                ct.Soluong = SoLuong;
                db.CHITIETDONTHANG.AddOrUpdate(ct);
            }
            db.SaveChanges();
            return Redirect("Index");
        }

        public ActionResult XoaGioHang(int MaDonHang, int MaSach)
        {
            var ct = db.CHITIETDONTHANG.FirstOrDefault(t => t.MaDonHang == MaDonHang && t.Masach == MaSach);
            db.CHITIETDONTHANG.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public ActionResult DatHang(int MaDonHang, FormCollection f )
        {
            var dh = db.DONDATHANG.FirstOrDefault(t => t.MaDonHang == MaDonHang);
            if (dh != null)
            {
                dh.Tinhtranggiaohang = false;
                dh.Ngaydat = DateTime.Parse(f["NgayDat"]);
                dh.Ngaygiao = DateTime.Parse(f["NgayGiao"]);
                dh.Dathanhtoan = false;
                dh.DiaChiGH = f["DiaChiGH"];
                dh.DienThoaiGH = f["DienThoaiGH"];
                db.DONDATHANG.AddOrUpdate(dh);
                db.SaveChanges();
            }
            return RedirectToAction("XacNhanDatHang", "GioHang");
        }
         public ActionResult XacNhanDatHang()
        {
            return View ();
        }


    }
}