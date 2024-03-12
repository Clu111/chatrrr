using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    private static Socket tcpClient;
    static void Main(string[] args)
    {
       var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            tcpClient.Connect("192.168.220.221", 12345);
            Console.WriteLine("Подключение к серверу выполнено успешно.");

            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        int num = 0;
        TimerCallback tm = new TimerCallback(Count);
        Timer timer = new Timer(tm, num, 0, 2000);

        Console.ReadLine();
    }

    public static void Count(object obj)
    {
        string path = @"C:/Users/is22-11/source/repos/ConsoleApp1/ewqeq/bin/Debug/net8.0/msgLog/";
        string newPath = @"C:/Desktop/index2.txt";
        FileInfo fileInf = new FileInfo(path);
        if (fileInf.Exists)
        {
            fileInf.CopyTo(newPath, true);
        }
    }

    static void SendBackGroundRequest(object state)
    {
        Console.WriteLine("Введите ip and команду для сообщения");
        string command = Console.ReadLine() + '\n';

    byte[] requestData = Encoding.UTF8.GetBytes(command);

    tcpClient.Send(requestData);
    }
}