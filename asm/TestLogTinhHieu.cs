using System;

namespace asm
{
    public class TinhHieu
    {
        public double Hieu(double a, double b)
        {
            if (!IsInteger(a) || !IsInteger(b))
            {
                throw new ArgumentException("a và b phải là số nguyên");
            }

            return a - b;
        }

        private bool IsInteger(double value)
        {
            return value == Math.Truncate(value);
        }
    }

    public class TestLogTinhHieu
    {
        private TinhHieu tinhHieu;

        [SetUp]
        public void Setup()
        {
            tinhHieu = new TinhHieu();
        }

        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(-5, 3, -8)]
        [TestCase(5, -3, 8)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MaxValue, 2, unchecked((int)((long)int.MaxValue - 2)))]
        [TestCase(int.MinValue, 2, unchecked((int)((long)int.MinValue - 2)))]
        [TestCase((long)int.MaxValue + 1, 1, unchecked((long)int.MaxValue + 1 - 1))]
        [TestCase((long)int.MinValue - 1, 1, unchecked((long)int.MinValue - 1 - 1))]
        [TestCase(int.MaxValue - 1, 1, unchecked((int)((long)int.MaxValue - 1 - 1)))]
        [TestCase(int.MinValue + 1, 1, unchecked((int)((long)int.MinValue + 1 - 1)))]
        public void TestHieuHaiSoNguyen(double a, double b, double expected)
        {
            double actual = tinhHieu.Hieu(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(2.5, 3)]
        [TestCase(2, 3.5)]
        [TestCase(2.5, 3.5)]
        public void TestHieuKhongPhaiSoNguyen(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => tinhHieu.Hieu(a, b));
        }
    }
}
