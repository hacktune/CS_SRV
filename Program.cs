using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
namespace PROXY_2
{
    class Twork {
        public void thread2()
        {
            while (true)
            {
                Console.WriteLine("2");
                Thread.Sleep(200);
            }
        }

    }


class MyTcpListener
{
    public static void Main()
    {
        TcpListener server = null;

            int i;
            Int32 port = 8080;
            IPAddress localAddr = IPAddress.Any;
            server = new TcpListener(localAddr, port);
            server.Start();
            Byte[] bytes = new Byte[1024];
            String data = null;
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                
                Console.WriteLine("Connected!");
                data = null;
                
                

           //     while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
               while(true)
               {
                   TcpClient client = server.AcceptTcpClient();
                    NetworkStream stream = client.GetStream();
                    FileStream fs = new FileStream("txt.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, stream.Read(bytes,0,bytes.Length));
                    Console.WriteLine(data);
                    //sw.WriteLine(data);

                    data = data.ToUpper();
                  //  byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                   // stream.Write(msg, 0, msg.Length);
                  //  Console.WriteLine("Sent: {0}", data);
           //       byte[] msg=System.Text.Encoding.ASCII.GetBytes(data);

                  
          byte[] msg = System.Text.Encoding.ASCII.GetBytes("HTTP/1.1 302 Found\nStatus: 302 Moved Temporarily\nX-Powered-By: PHP/5.4.5\nLocation: http://kldp.org\nContent-type: text/html; charset=utf-8\nDate: Sun, 02 Dec 2012 22:28:40 GMT\nServer: lighttpd/1.4.30\n");
               
                   NetworkStream wstream = client.GetStream();

                  wstream.Write(msg, 0, msg.Length);

                    sw.Flush();
                    sw.Close();
                    fs.Close(); wstream.Close(0);
                    client.Close();  
                }

               
            } 
            //server.Stop();


        //Console.WriteLine("\nHit enter to continue...");
   //     Console.Read();
    }
}
}
/*
namespace PROXY_2
{
    class threadwork
    {
        public void thread1()
        {
            while (true)
            {
            }
        }
        public void thread2()
        {
            while (true)
            {
                Console.WriteLine("2");
                Thread.Sleep(200);
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            threadwork work = new threadwork();
            ThreadStart td1 = new ThreadStart(work.thread1);
            ThreadStart td2 = new ThreadStart(work.thread2);
            Thread t1 = new Thread(td1);
            Thread t2 = new Thread(td2);
            Socket server;
            Socket client;
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8080);
            server.Bind(ipep);
            
            while (true)
            {
                server.Listen(10000);
            
            }
            client = server.Accept();


            t1.Start();
            t2.Start();


        }
    }
}
  */  
    /*
    class NetworkTest
    {

        private Socket server;
        private Socket client;

        private void ServerOpen()
        {

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9999);
            server.Bind(ipep);
            server.Listen(5);

            Console.WriteLine("클라이언트 연결을 대기합니다.");

            client = server.Accept();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("클라이언트로 보낼 내용은 ==> ");
                string str = Console.ReadLine();
                Writer(str);
            }
        }

        private void Writer(string str)
        {
            NetworkStream stream = new NetworkStream(client);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(str);
            writer.Flush();
        }


        static void Main(string[] args)
        {
            NetworkTest networktest = new NetworkTest();

            networktest.ServerOpen();
            Console.ReadLine();
        }
    }
}
    */