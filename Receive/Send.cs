using RabbitMQ.Client;
using System;
using System.Text;

namespace Receive
{
    class Send
    {
        static void Main(string[] args)
        {
            //1.1实例化一个连接工厂
            var factory = new ConnectionFactory() { HostName = "localhost" };
            //2.建立连接
            using (var connection=factory.CreateConnection())
            {
                //3.建立信道
                using (var channel=connection.CreateModel())
                {
                    //4.申明队列
                    channel.QueueDeclare(queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    string message = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "hello",
                        basicProperties: null,
                        body: body);
                    Console.WriteLine("[X] Sent {0}", message);
                }

                Console.WriteLine("Press [enter] to exit.");
                Console.ReadLine();
            }
         

        }
    }
}
