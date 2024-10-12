
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Server:");
var server = new UdpClient(27001);
var remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

try
{
    while (true)
    {
        Console.WriteLine("Waiting for a message...");

        var bytes = server.Receive(ref remoteEndPoint);
        Console.WriteLine($"Received {bytes.Length} bytes from {remoteEndPoint.Address}:{remoteEndPoint.Port}");

        var path = @"C:\Users\User\OneDrive - ITM STEP MMC\Desktop\Walpaper\received_image.jpg";

        using (var writeF = new FileStream(path, FileMode.Append, FileAccess.Write))
        {
            writeF.Write(bytes, 0, bytes.Length);
            Console.WriteLine("Image downloaded...");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
finally
{
    server.Close();
}
