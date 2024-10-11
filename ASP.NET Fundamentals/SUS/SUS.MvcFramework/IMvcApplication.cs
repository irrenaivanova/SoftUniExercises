using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public  interface IMvcApplication
    {
        void ConfigureServices();
        void Configure(List<Route> routeTable);
    }
}
