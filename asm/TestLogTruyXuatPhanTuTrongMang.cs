using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asm
{
    public class TruyXuatPhanTuTrongMang
    {
        public int GetElementFromArray(int[] array, int index)
        {
            return array[index];
        }
    }
    public class TestLogTruyXuatPhanTuTrongMang
    {
        private TruyXuatPhanTuTrongMang _truyXuatPhanTuTrongMang;

        [SetUp]
        public void Setup()
        {
            _truyXuatPhanTuTrongMang = new TruyXuatPhanTuTrongMang();
        }

        [Test]
        public void Test1()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int expectedElement = 3;
            int index = 2;

            int actualElement = _truyXuatPhanTuTrongMang.GetElementFromArray(numbers, index);

            Assert.AreEqual(expectedElement, actualElement);
        }

        [Test]
        public void Test2()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int index = 5;

            Assert.Throws<IndexOutOfRangeException>(() => _truyXuatPhanTuTrongMang.GetElementFromArray(numbers, index));
        }
    }
}

