using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SachOnline3.Models
{
    public partial class Model1 : DbContext
    {
        public Model1() : base("name=Model11")
        {
        }

        public virtual DbSet<CHITIETDONTHANG> CHITIETDONTHANG { get; set; }
        public virtual DbSet<CHUDE> CHUDE { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANG { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBAN { get; set; }
        public virtual DbSet<SACH> SACH { get; set; }
        public virtual DbSet<TACGIA> TACGIA { get; set; }
        public virtual DbSet<VIETSACH> VIETSACH { get; set; }
        public virtual DbSet<USER> User { get; set; }

        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETDONTHANG>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONTHANG)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Taikhoan)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DienthoaiKH)
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Giaban)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Anhbia)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CHITIETDONTHANG)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.VIETSACH)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TACGIA>()
                .Property(e => e.Dienthoai)
                .IsUnicode(false);

            modelBuilder.Entity<TACGIA>()
                .HasMany(e => e.VIETSACH)
                .WithRequired(e => e.TACGIA)
                .WillCascadeOnDelete(false);
        }
    }
}
