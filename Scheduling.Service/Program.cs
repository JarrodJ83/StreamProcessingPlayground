using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace Scheduling.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consumer = new Consumer<int, string>(new Dictionary<string, object> 
                        { 
                            { "bootstrap.servers", "localhost:9092" } ,
                            { "group.id", Guid.NewGuid() } 
                        }, new IntDeserializer(), new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg)
                => Console.WriteLine($"Read '{msg.Value}' from: {msg.TopicPartitionOffset}");

                consumer.OnError += (_, error)
                => Console.WriteLine($"Error: {error}");

                consumer.OnConsumeError += (_, msg)
                => Console.WriteLine($"Consume error ({msg.TopicPartitionOffset}): {msg.Error}");

                consumer.Subscribe("user-registration");

                Console.Write("Listening for events");
                while (true)
                {
                    consumer.Poll(TimeSpan.FromMilliseconds(100));
                }
            }
         }
    }
}
