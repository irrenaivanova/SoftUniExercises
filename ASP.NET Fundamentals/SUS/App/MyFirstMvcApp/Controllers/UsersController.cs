using SUS.HTTP;
using SUS.MvcFramework;

using System.Text;


namespace MyFirstMvcApp.Controllers 
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>login</h1>";
            var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
            return response;
        }
        public HttpResponse Register(HttpRequest request)
        {
            return View();
        }
    }
}
