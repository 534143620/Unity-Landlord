using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System;

namespace SocketDemo
{
    class Program
    {
        /// <summary>
        ///     AddressFamily.InterNetwork 地址族
        ///     SocketType.Stream 指定类型
        ///     ProtocolType.Tcp 指定协议
        ///     
        ///     服务器：
        ///     接受请求
        ///     发送数据
        ///     接受数据
        ///     断开连接
        ///     
        /// </summary>
        /// 
        private static Socket serverSocket = null;
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //进行绑定
            //端口号范围0-65535
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any,9999);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);
            //开一个线程接受客户端连接
            Thread thread = new Thread(listenClientConnect);
            thread.Start();
        }

        //监听客户端连接
        private static void listenClientConnect()
        {
            //等待 有客户端连接的时候 就会触发这个函数 返回一个客户端的socket对象
            Socket clientSocket = serverSocket.Accept();
            //给客户端发送一个消息
            clientSocket.Send(Encoding.Default.GetBytes("服务器告诉你连接成功"));
            Thread recThread = new Thread(receiveClientMessage);
            recThread.Start(clientSocket);
        }

        //接受来自客户端的消息
        private static void receiveClientMessage(object clientSocket)
        {
            Socket socket = clientSocket as Socket;
            byte[] buffer = new byte[1024];
            //接收到数据的长度
            int length = socket.Receive(buffer);
            //显示出来
            Console.WriteLine(Encoding.Default.GetString(buffer, 0, length));
        }
    }

}
