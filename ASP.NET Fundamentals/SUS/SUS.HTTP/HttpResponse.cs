using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class  HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, StatusCode statusCode = StatusCode.OK)
        {
            if (body==null)
            {
                throw new ArgumentNullException(nameof(body));
            }
            StatusCode = statusCode;
            Body = body;
            Headers = new List<Header>()
            {
                {new Header ("Content-Type",contentType)},
                {new Header ("Content-Length",body.Length.ToString())},
            };
            Cookies = new List<ResponseCookie> ();
        }

        public StatusCode StatusCode { get; set; }
        public ICollection<Header> Headers { get; set; }
        public ICollection<ResponseCookie> Cookies { get; set; }

        public byte[] Body { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}");
            sb.Append(HttpConstants.NewLine);
            foreach (var header in Headers)
            {
                sb.Append($"{header.Name}: {header.Value}");
                sb.Append(HttpConstants.NewLine);
            }

            foreach (var cookie in Cookies)
            {
                sb.Append($"Set-Cookie: {cookie.ToString()}");
                sb.Append(HttpConstants.NewLine);
            }
            sb.Append(HttpConstants.NewLine);
            return sb.ToString();
        }
    }
}
