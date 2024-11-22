using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asm
{
    public class TinhTrungBinhCong()
    {
        public double Tbc(List<double> numbers)
        {
             double tong = 0;
            foreach (double number in numbers)
            {
                tong += number;
            }
            if (numbers.Count == 0)
            {
                throw new ArgumentException("mảng không được để chống");
            }
           

            return tong / numbers.Count;
        }
    }
    public class TestLogTrungBinhCong
    {
        private TinhTrungBinhCong _tinhTrungBinhCong;

        [SetUp]
        public void ChuanBi()
        {
            _tinhTrungBinhCong = new TinhTrungBinhCong();
        }
        [Test]
        [TestCase(new[] { 1.0, 2.0, 3.0 }, 2.0)]
        [TestCase(new[] {0.0}, 0)]

        public void TestTrungBinhCongNhieuSo(double[] numbers, double expected)
        {
            double actual = _tinhTrungBinhCong.Tbc(new List<double>(numbers));
            if (numbers.Count() == 0)
            {
                Assert.Throws<AggregateException>(() => _tinhTrungBinhCong.Tbc(new List<double>(numbers)));
            }
            else
            {
                Assert.AreEqual(expected, actual);

            }
        }



    }
}

