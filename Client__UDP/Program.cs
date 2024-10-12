using System.Net;
using System.Net.Sockets;
using System.IO;

Console.WriteLine("Client:");

var client = new UdpClient();
var endPoint = new IPEndPoint(IPAddress.Loopback, 27001);

try
{
    var filePath = @"C:\Users\User\OneDrive - ITM STEP MMC\Desktop\Walpaper\.IMG_20230801_222634.jpg";

    if (!File.Exists(filePath))
    {
        Console.WriteLine("File does not exist.");
        return;
    }

    using (var readF = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        var buffer = new byte[1024];
        int len;
        while ((len = readF.Read(buffer, 0, buffer.Length)) > 0)
        {
            client.Send(buffer, len, endPoint);
            Console.WriteLine($"Sent {len} bytes...");
        }
    }

    Console.WriteLine("File transfer complete.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    client.Close();
}
