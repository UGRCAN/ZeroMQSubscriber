using NetMQ;
using NetMQ.Sockets;
using System;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var subscriber = new SubscriberSocket())
            {
                subscriber.Connect("tcp://publisher:1234"); //publisher is container name of publisher( due to ip binding )
                subscriber.Subscribe("A"); //A is topic name

                while (true)
                {
                    //var topic = subscriber.ReceiveFrameString();
                    var topicAndMsg = subscriber.ReceiveFrameString();
                    Console.WriteLine("From Server:  {0}", topicAndMsg.Substring(1));
                }
            }
        }
    }
}
