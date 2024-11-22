namespace asm
{
    public class TinhTong
    {
        public double Tong(double a, double b)
        {
            if (a != Math.Floor(a) || b != Math.Floor(b))
            {
                throw new ArgumentException("a và b phải là số nguyên");
            }

            return a + b;
        }
    }
    public class Tests
    {
        private TinhTong _tinhTong;

        [SetUp]
        public void Setup()
        {
            _tinhTong = new TinhTong();
        }

        [Test]
        [TestCase(5, 10, 15)]
        [TestCase(-5, 10, 5)]
        [TestCase(5, -10, -5)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MaxValue, int.MaxValue, unchecked((int)((long)int.MaxValue + (long)int.MaxValue)))]
        [TestCase(int.MinValue, int.MinValue, unchecked((int)((long)int.MinValue + (long)int.MinValue)))]
        [TestCase((long)int.MaxValue + 1, (long)int.MaxValue + 1, unchecked((long)((long)int.MaxValue + (long)int.MaxValue)))]
        [TestCase((long)int.MinValue - 1, (long)int.MinValue - 1, unchecked((long)((long)int.MinValue + (long)int.MinValue)))]
        [TestCase(int.MaxValue - 1, int.MaxValue - 1, unchecked((int)((long)int.MaxValue + (long)int.MaxValue)))]
        [TestCase(int.MinValue + 1, int.MinValue + 1, unchecked((int)((long)int.MinValue + (long)int.MinValue)))]
        public void TestTongHaiSoNguyen(double a, double b, double expected)
        {
            double actual = _tinhTong.Tong(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("5.5", "10.5")]
        public void TestTongHaiSoKhongPhaiSoNguyen(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => _tinhTong.Tong(a, b));
        }
    }
}