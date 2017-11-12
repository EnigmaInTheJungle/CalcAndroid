using System;
using NUnit.Framework;
using CalcA;

namespace CalcUnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void Es()
        {
        }

        [Test]
        [TestCase(1, 2, "+", 3)]
        [TestCase(12, 2, "-", 10)]
        [TestCase(7, 2, "*", 14)]
        [TestCase(6, 2, "/", 3)]
        public void TestCalcWF(double x, double y, string op, double res)
        {
            Assert.AreEqual(res, Calculate.Calc(x,y,op));
        }
    }
}
