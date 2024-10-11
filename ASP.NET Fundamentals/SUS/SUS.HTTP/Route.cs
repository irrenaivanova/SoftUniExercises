
namespace SUS.HTTP
{
    public class Route
    {
        public Route(string name,HttpMethod method, Func<HttpRequest, HttpResponse> action)
        {
            Name = name;
            Action = action;
            Method = method;
        }
        public HttpMethod Method { get; set; }

        public string Name { get; set; }
        public Func<HttpRequest, HttpResponse> Action { get; set; }
    }
}
