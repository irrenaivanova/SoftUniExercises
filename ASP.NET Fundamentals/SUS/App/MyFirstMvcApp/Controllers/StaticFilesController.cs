using SUS.HTTP;
using SUS.MvcFramework;

namespace MyFirstMvcApp.Controllers 
{
    public class StaticFilesController : Controller
    {
        public HttpResponse FavIcon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vbd.microsoft.icon");
        }
    }
}
