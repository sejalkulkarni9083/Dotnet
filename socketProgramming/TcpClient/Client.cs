using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        try
        {
            // Step 1: Connect to Server
            TcpClient client =
                new TcpClient("localhost", 5000);

            Console.WriteLine("Connected to server");

            // Step 2: Get Stream
            NetworkStream stream = client.GetStream();

            // Step 3: Send Message
            string msg = "Hello Server!";

            byte[] data =
                Encoding.UTF8.GetBytes(msg);

            stream.Write(data, 0, data.Length);

            // Step 4: Read Response
            byte[] buffer = new byte[1024];

            int bytesRead =
                stream.Read(buffer, 0, buffer.Length);

            string response =
                Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Server says: " + response);

            // Step 5: Close
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
