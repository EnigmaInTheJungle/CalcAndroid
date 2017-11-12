using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace CalcUnitTest
{
    public class Pom
    {
        public Func<AppQuery, AppQuery> FirstNumber { get; } = c => c.Id("firstNumber");

        public Func<AppQuery, AppQuery> SecondNumber { get; } = c => c.Id("secondNumber");

        public Func<AppQuery, AppQuery> Operation { get; } = c => c.Id("Oper");

        public Func<AppQuery, AppQuery> btnCalc { get; } = c => c.Id("buttonCalc");

        public Func<AppQuery, AppQuery> textResult { get; } = c => c.Id("textResult");
    }
}
