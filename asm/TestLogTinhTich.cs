using System;

namespace asm
{
    public class TinhTich
    {
        public double Tich(double a, double b)
        {
            if (a == Math.Floor(a) && b == Math.Floor(b))
            {
                return a * b;
            }
            else
            {
                throw new ArgumentException("Các tham số phải là số nguyên.");
            }
        }
    }

    public class TestLogTinhTich
    {
        private TinhTich tinhTich;

        [SetUp]
        public void Setup()
        {
            tinhTich = new TinhTich();
        }

        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(-2, 3, -6)]
        [TestCase(0, 3, 0)]
        [TestCase(int.MaxValue, 2, unchecked((int)((long)int.MaxValue * 2)))]
        [TestCase(int.MinValue, 2, unchecked((int)((long)int.MinValue * 2)))]
        public void TestTichHaiSoNguyen(double a, double b, double c)
        {
            double actual = tinhTich.Tich(a, b);
            Assert.AreEqual(c, actual);
        }

        [Test]
        [TestCase(2.5, 3)]
        [TestCase(2, 3.5)]
        [TestCase(2.5, 3.5)]
        public void TestTichKhongPhaiSoNguyen(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => tinhTich.Tich(a, b));
        }
    }
}
