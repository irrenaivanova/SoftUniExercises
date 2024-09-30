
using System.Net.Sockets;
using System.Text;

await Server();
static async Task ReadData()
{
    string url = @"https://softuni.bg/trainings/4768/html5-and-css3-september-2024";
    HttpClient client = new HttpClient();

    var response = await client.GetAsync(url);
    var vic = await response.Content.ReadAsStringAsync();   
    var html = await client.GetStringAsync(url);
    Console.WriteLine(html);
}

static async Task Server()
{
    TcpListener listener = new TcpListener
        (System.Net.IPAddress.Loopback, 12345);
    listener.Start();
    while(true)
    {
        var client = listener.AcceptTcpClient();
        using var stream = client.GetStream();
        byte[] buffer = new byte[100000];
        var length = stream.Read(buffer, 0, buffer.Length);
        string reqString = Encoding.UTF8.GetString(buffer);
        Console.WriteLine(reqString);

        const string newLine = "\r\n";
        string html = $"<h1>Hello from Irena {DateTime.Now}</h1>";
        byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
        string responseHeaders = "HTTP/1.1 200 OK" + newLine +
                "Server: IrenaServer 2020" + newLine +
                "Content-Type: text/html; charset=utf-8" + newLine +
                "Set-Cookie: sid=kshfkjsh555" + newLine+
                "Content-Length: " + htmlBytes.Length + newLine +
                newLine;
        byte[] headerBytes = Encoding.UTF8.GetBytes(responseHeaders);
        stream.Write(headerBytes, 0, headerBytes.Length);
        stream.Write(htmlBytes, 0, htmlBytes.Length);
        Console.WriteLine(responseHeaders + html);
    }
}