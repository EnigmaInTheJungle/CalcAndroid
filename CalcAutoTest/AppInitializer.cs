using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace CalcUnitTest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("CalcA.CalcA")
                    .StartApp();
            }
            else
            {
                return ConfigureApp
                .iOS
                .StartApp();
            }
        }
    }
}
