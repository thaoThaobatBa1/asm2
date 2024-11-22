using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace asm
{
    public class Sinhvien
    {
        public string Id { get; set; }
        public string HoTen { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string MaSV { get; set; }

        public Sinhvien(string id, string hoTen, string maLop, string tenLop, string maSV)
        {
            Id = id;
            HoTen = hoTen;
            MaLop = maLop;
            TenLop = tenLop;
            MaSV = maSV;
        }
    }
    public class SinhVienPoly
    {
        private List<Sinhvien> sinhVienList = new List<Sinhvien>();

        public void ThemSinhVien(Sinhvien sv)
        {
            if (!IsValidTenLop(sv.TenLop) ||  string.IsNullOrEmpty(sv.TenLop))
            {
                throw new ArgumentException("Tên lớp không được chứa ký tự đặc biệt hoặc để tróng.");
            }
            sinhVienList.Add(sv);
        }

        public Sinhvien TimKiemTheoMaSV(string maSV)
        {
            return sinhVienList.FirstOrDefault(sv => sv.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsValidTenLop(string tenLop)
        {
            return !Regex.IsMatch(tenLop, @"[!@#$%^&*(),.?""':{}|<>]");
        }

    }
    public class TestLogSinhVienPoly
    {
        private SinhVienPoly _sinhVienPoly;

        [SetUp]
        public void Setup()
        {
            _sinhVienPoly = new SinhVienPoly();
        }

        [Test]
        public void TestThemSinhVien_Valid()
        {
            var sv = new Sinhvien("1", "Nguyen Van A", "L01", "Lop 1", "SV001");

            _sinhVienPoly.ThemSinhVien(sv);

            Assert.Pass("Thêm sinh viên thành công.");
        }

        [Test]
        public void TestThemSinhVien_TenLopChuaKyTuDacBiet()
        {
            var sv = new Sinhvien("2", "Nguyen Van B", "L02", "Lop@2", "SV002");

            Assert.Throws<ArgumentException>(() => _sinhVienPoly.ThemSinhVien(sv));
        }

        [Test]
        public void TestThemSinhVien_TenLopHopLe()
        {
            var sv = new Sinhvien("3", "Nguyen Van C", "L03", "Lop 3", "SV003");

            _sinhVienPoly.ThemSinhVien(sv);

            Assert.Pass("Thêm sinh viên thành công.");
        }

        [Test]
        public void TestThemSinhVien_TenLopRong()
        {
            var sv = new Sinhvien("4", "Nguyen Van D", "L04", "", "SV004");
            Assert.Throws<ArgumentException>(() => _sinhVienPoly.ThemSinhVien(sv));
        }

        [Test]
        public void TestThemSinhVien_TenLopChuaSo()
        {
            var sv = new Sinhvien("5", "Nguyen Van E", "L05", "Lop 5", "SV005");
            _sinhVienPoly.ThemSinhVien(sv);
            Assert.Pass("Thêm sinh viên thành công.");
        }

        [Test]
        public void TestThemSinhVien_TenLopCoKyTuDacBiet()
        {
            var sv = new Sinhvien("6", "Nguyen Van F", "L06", "Lop#6", "SV006");
            Assert.Throws<ArgumentException>(() => _sinhVienPoly.ThemSinhVien(sv));
        }

        [Test]
        public void TestThemSinhVien_TenLopCoKyTuDacBietKhac()
        {
            var sv = new Sinhvien("7", "Nguyen Van G", "L07", "Lop%7", "SV007");
            Assert.Throws<ArgumentException>(() => _sinhVienPoly.ThemSinhVien(sv));
        }

        [Test]
        public void TestThemSinhVien_TenLopCoKyTuDacBietKhac2()
        {
            var sv = new Sinhvien("8", "Nguyen Van H", "L08", "Lop@8", "SV008");
            Assert.Throws<ArgumentException>(() => _sinhVienPoly.ThemSinhVien(sv));
        }

        [Test]
        public void TestTimKiemTheoMaSV_HopLe()
        {
            var sv = new Sinhvien("9", "Nguyen Van I", "L09", "Lop 9", "SV009");
            _sinhVienPoly.ThemSinhVien(sv);

            var result = _sinhVienPoly.TimKiemTheoMaSV("SV009");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nguyen Van I", result.HoTen);
        }

        [Test]
        public void TestTimKiemTheoMaSV_KhongTonTai()
        {
            var result = _sinhVienPoly.TimKiemTheoMaSV("SV999");
            Assert.IsNull(result);
        }

        [Test]
        public void TestTimKiemTheoMaSV_KhongPhanBietChuHoaVaChuThuong()
        {
            var sv = new Sinhvien("10", "Nguyen Van J", "L10", "Lop 10", "SV010");
            _sinhVienPoly.ThemSinhVien(sv);

            var result = _sinhVienPoly.TimKiemTheoMaSV("sv010");
            Assert.IsNotNull(result);
            Assert.AreEqual("Nguyen Van J", result.HoTen);
        }

        [Test]
        public void TestTimKiemTheoMaSV_Rong()
        {
            var result = _sinhVienPoly.TimKiemTheoMaSV("");
            Assert.IsNull(result);
        }

        [Test]
        public void TestTimKiemTheoMaSV_Null()
        {
            var result = _sinhVienPoly.TimKiemTheoMaSV(null);
            Assert.IsNull(result);
        }
    }
}

