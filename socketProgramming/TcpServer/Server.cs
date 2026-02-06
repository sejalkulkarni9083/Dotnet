using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main()
    {
        try
        {
            // Step 1: Create Listener
            TcpListener server =
                new TcpListener(IPAddress.Any, 5000);

            // Step 2: Start Listening
            server.Start();

            Console.WriteLine("Server started...");
            Console.WriteLine("Waiting for client...");

            // Step 3: Accept Client
            TcpClient client = server.AcceptTcpClient();

            Console.WriteLine("Client connected!");

            // Step 4: Get Stream
            NetworkStream stream = client.GetStream();

            // Step 5: Read Data
            byte[] buffer = new byte[1024];

            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string message =
                Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Client says: " + message);

            // Step 6: Send Response
            string reply =
                "Hello Client, I received: " + message;

            byte[] data =
                Encoding.UTF8.GetBytes(reply);

            stream.Write(data, 0, data.Length);

            // Step 7: Close
            client.Close();
            server.Stop();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
