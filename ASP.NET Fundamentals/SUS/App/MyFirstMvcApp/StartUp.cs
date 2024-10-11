using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class StartUp : IMvcApplication
    {
     
        public void ConfigureServices()
        {

        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/",SUS.HTTP.HttpMethod.GET, new HomeController().Index));
            routeTable.Add(new Route("/users/login", SUS.HTTP.HttpMethod.GET, new UsersController().Login));
            routeTable.Add(new Route("/users/register", SUS.HTTP.HttpMethod.GET, new UsersController().Register));
            routeTable.Add(new Route("/favicon.ico", SUS.HTTP.HttpMethod.GET, new StaticFilesController().FavIcon));
        }
    }
}
