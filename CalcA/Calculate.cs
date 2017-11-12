using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CalcA
{
    public class Calculate
    {
        public static double Calc(double x, double y, string operation)
        {
            double result = 0;

            if (operation == "+")
                result = x + y;
            else if (operation == "-")
                result = x - y;
            else if (operation == "*")
                result = x * y;
            else if (operation == "/")
                result = x / y;
            return result;
        }
    }
}