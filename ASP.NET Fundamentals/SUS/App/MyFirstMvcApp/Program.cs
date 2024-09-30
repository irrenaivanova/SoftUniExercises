
using SUS.HTTP;
using System.Text;

public class Program
{
    static async Task Main(string[] args)
    {
        IHttpServer server = new HttpServer();

        server.AddRoute("/", HomePage);
        server.AddRoute("/about", About);
        server.AddRoute("/users/login", Login);
        server.AddRoute("/favicon.ico", FavIcon);
        await server.StartAsync(80);
    }

    static HttpResponse FavIcon(HttpRequest request)
    {
     
        var response = new HttpResponse("image/x-icon", File.ReadAllBytes("favicon.ico"));
        return response;
    }


    static HttpResponse HomePage(HttpRequest request)
    {
        var responseHtml = "<h1>Welcome!</h1>";
        var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
       
        return response;
    }

    static HttpResponse About(HttpRequest request)
    {
        var responseHtml = "<h1>About</h1>";
        var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
        return response;
    }
    static HttpResponse Login(HttpRequest request)
    {
        var responseHtml = "<h1>login</h1>";
        var response = new HttpResponse("text/html", Encoding.UTF8.GetBytes(responseHtml));
        return response;
    }
}
