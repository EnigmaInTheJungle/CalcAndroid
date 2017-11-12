using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System;
using static Android.Views.View;
using Android.Views;

namespace CalcA
{
    [Activity(Label = "CalcA", MainLauncher = true)]
    public class MainActivity : Activity, IOnClickListener
    {
        Button buttonCalc;
        EditText firstnumber;
        EditText secondnumber;
        EditText oper;
        double x = 0;
        double y = 0;
        string op = "";


        HttpClient client;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            client = new HttpClient();

            firstnumber = FindViewById<EditText>(Resource.Id.firstNumber);
            secondnumber = FindViewById<EditText>(Resource.Id.secondNumber);
            oper = FindViewById<EditText>(Resource.Id.Oper);

            buttonCalc = FindViewById<Button>(Resource.Id.buttonCalc);
            buttonCalc.SetOnClickListener(this);
            buttonCalc.Click += calc_Click;

        }

        public void calc_Click(object sender, EventArgs e)
        {
            TextView tv = FindViewById<TextView>(Resource.Id.textResult);
            x = double.Parse(firstnumber.Text.ToString());
            y = double.Parse(secondnumber.Text.ToString());
            op = oper.Text;
            //tv.Text = Task.Run(() => Calculate(x, y, op)).Result;
            tv.Text = Calculate.Calc(x, y, op).ToString();
        }

        //public async Task<string> Calculate(double a, double b, string op)
        //{
        //    var param = "a=" + a + "&b=" + b + "&op=" + op;
        //    string response = await client.GetStringAsync("http://192.168.0.103:8888?" + param);
        //    return response;
        //}

        

        public void OnClick(View v)
        {
            throw new NotImplementedException();
        }
    }
}

