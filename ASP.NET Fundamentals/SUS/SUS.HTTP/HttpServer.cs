using SUS.HTTP;
using System.Data;
using System.Net.Sockets;
using System.Text;

public class HttpServer:IHttpServer
{

    List<Route> routeTable;
    public HttpServer(List<Route> routeTable)
    {
      this.routeTable = routeTable;
    }

    public async Task StartAsync(int port)
    {
        var listener = new TcpListener(System.Net.IPAddress.Loopback,port);
        listener.Start();
        while(true)
        {
            var client = await listener.AcceptTcpClientAsync();
            ProcessClientAsync(client);
        }
    }

    private async Task ProcessClientAsync(TcpClient client)
    {
        List<byte> data = new List<byte>();
        using var stream = client.GetStream();
        byte[] buffer = new byte[HttpConstants.BufferSize];
        int position = 0;
        while(true)
        {
            int count = await stream.ReadAsync(buffer, position, buffer.Length);
            position += count;

            if (count<buffer.Length)
            {
                byte[] last = new byte[count];
                Array.Copy(buffer, last, count);
                data.AddRange(last);
                break;
            }
            else
            {
                data.AddRange(buffer);
            }
        }
        string requestString = Encoding.UTF8.GetString(data.ToArray());
        var request = new HttpRequest(requestString);
        
        Console.WriteLine(requestString);

        HttpResponse response;
        var route = routeTable.FirstOrDefault(x => string.Compare(x.Name,request.Path,true)==0 && x.Method==request.Method);
        if (route != null)
        {
            response = route.Action(request);
        }
        else
        {
            response = new HttpResponse("text/html", new byte[0], StatusCode.NotFound);
        }
        response.Headers.Add(new Header("Server", HttpConstants.Servername));
        response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()));
        var responseHeader = Encoding.UTF8.GetBytes(response.ToString());
        stream.Write(responseHeader, 0, responseHeader.Length);
        stream.Write(response.Body, 0, response.Body.Length);
        stream.Close();
     
    }
}