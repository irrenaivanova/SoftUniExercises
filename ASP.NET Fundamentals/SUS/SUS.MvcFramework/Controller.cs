using SUS.HTTP;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            var bodyHtml = System.IO.File.ReadAllText("Views/"+ GetType().Name.Replace("Controller",string.Empty)+"/"+viewPath+".cshtml");
            var responseHtml = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml").Replace("{{RenderBody}}", bodyHtml);
            var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            byte[] file = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, file);
            return response;
        }
    }
}