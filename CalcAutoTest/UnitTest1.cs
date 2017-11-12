using System;
using NUnit.Framework;
using Xamarin.UITest;
using CalcUnitTest;
using Xamarin.UITest.Queries;

namespace CalcAutoTest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        private Pom calc;

        public Tests(Platform platform)
        {
            this.platform = platform;
            calc = new Pom();
        }


        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[TearDown]
        //public void ClearField()
        //{
        //    app.ClearText(calc.FirstNumber);
        //    app.ClearText(calc.SecondNumber);
        //    app.ClearText(calc.Operation);
        //}

        [TestCase("firstNumber")]
        [TestCase("secondNumber")]
        [TestCase("Oper")]
        [TestCase("buttonCalc")]
        public void ExistingElementTest(string elID)
        {
            AppResult[] results = app.Query(c => c.Marked(elID));
            Assert.IsTrue(results.Length != 0);
        }

        [TestCase("52", "23", "52", "23")]
        [TestCase("611", "344", "611", "344")]
        [TestCase("7456", "4654", "7456", "4654")]
        [TestCase("82340", "10900", "82340", "10900")]
        public void TestComplex(string but1, string but2, string resFN, string resSN)
        {
            app.Tap(calc.FirstNumber);
            app.EnterText(but1);
            app.Tap(calc.SecondNumber);
            app.EnterText(but2);
            AppResult[] fn = app.Query(calc.FirstNumber);
            AppResult[] sn = app.Query(calc.SecondNumber);
            Assert.AreEqual(resFN, fn[0].Text);
            Assert.AreEqual(resSN, sn[0].Text);
        }

        [TestCase("5", "2", "+", "5", "2", "+")]
        [TestCase("6", "3", "-", "6", "3", "-")]
        [TestCase("7", "4", "*", "7", "4", "*")]
        [TestCase("8", "1", "/", "8", "1", "/")]
        public void SimpleTest(string a, string b, string op, string resFN, string resSN, string resOp)
        {
            app.Tap(calc.FirstNumber);
            app.EnterText(a);
            app.Tap(calc.SecondNumber);
            app.EnterText(b);
            app.Tap(calc.Operation);
            app.EnterText(op);
            AppResult[] fn = app.Query(calc.FirstNumber);
            AppResult[] sn = app.Query(calc.SecondNumber);
            AppResult[] oper = app.Query(calc.Operation);
            Assert.AreEqual(resFN, fn[0].Text);
            Assert.AreEqual(resSN, sn[0].Text);
            Assert.AreEqual(resOp, oper[0].Text);
        }

        [TestCase("11", "7", "+", "18")]
        [TestCase("14", "3", "-", "11")]
        [TestCase("15", "6", "*", "90")]
        [TestCase("80", "20", "/", "4")]
        public void Calc_RealJob(string a, string b, string op, string expRes)
        {
            app.Tap(calc.FirstNumber);
            app.EnterText(a);
            app.Tap(calc.SecondNumber);
            app.EnterText(b);
            app.Tap(calc.Operation);
            app.EnterText(op);
            app.Tap(calc.btnCalc);
            AppResult[] results = app.Query(calc.textResult);
            Assert.AreEqual(expRes, results[0].Text);
        }
    }
}
