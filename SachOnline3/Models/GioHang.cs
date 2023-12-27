using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline3.Models
{
    public class GioHang
    {
        Model1 db = new Model1();

        public int iMaSach { get; set; }
        public string sTenSach { get; set; }

        public string sAnhBia { get; set; }

        public double dDonGia { get; set; }

        public int  iSoLuong { get; set; }

        public double dThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int ms)
        {
            iMaSach = ms;
            SACH s = db.SACH.Single(n => n.Masach == iMaSach);
            sTenSach = s.Tensach;
            sAnhBia = s.Anhbia;
            dDonGia = double.Parse(s.Giaban.ToString());
            iSoLuong = 1;
        }
    }
}