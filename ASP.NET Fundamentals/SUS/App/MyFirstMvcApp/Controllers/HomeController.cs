using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public  HttpResponse Index(HttpRequest request)
        {
            var responseHtml = "<h1>Welcome!</h1>";
            var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
            return response;
        }

        public HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About</h1>";
            var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
            return response;
        }
    }
}
