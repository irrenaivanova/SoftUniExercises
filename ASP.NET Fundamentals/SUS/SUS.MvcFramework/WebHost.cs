using MyFirstMvcApp;
using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public  class WebHost 
    {
        public static async Task RunAsync(IMvcApplication application, int port = 80)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);
            IHttpServer server = new HttpServer(routeTable);
            await server.StartAsync(port);
        }
    }
}
