using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString) 
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            var lines = requestString.Split(HttpConstants.NewLine);
            var headerLine = lines[0];
            var headerlineParts = headerLine.Split(' ');
            
            Method = Enum.Parse<HttpMethod>(headerlineParts[0]);
            Path = headerlineParts[1];
            bool isInHeader = true;
            
            StringBuilder bodybuilder = new StringBuilder();
            
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }

                if (isInHeader)
                {
                    var header = new Header(line);
                    Headers.Add(header);
                }
                else
                {
                    bodybuilder.AppendLine(line);
                }
            }
            Body = bodybuilder.ToString();

            var cookiesHeader = Headers.FirstOrDefault(x => x.Name == "Cookie");
            if (cookiesHeader!=null)
            {
                var cookies = cookiesHeader.Value.Split(new string[] {"; "},2,StringSplitOptions.RemoveEmptyEntries);
                foreach (var cookiAsString in cookies)
                {
                    var Cookie = new Cookie(cookiAsString);
                    Cookies.Add(Cookie);
                }
            }
        }

        public HttpMethod Method { get; set; }
        public string Path { get; set; }
        public ICollection<Header> Headers { get; set; } 
        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}
