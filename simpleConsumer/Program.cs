using System;
using Confluent.Kafka;


namespace simpleConsumer
{
    class Program
    {
        const string KafkaServer = "127.0.0.1:9092";
        const string KafkaTopic = "testTopic";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var configConsumer = new ConsumerConfig
            {
                BootstrapServers = KafkaServer,
                GroupId = "teste",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(configConsumer).Build())
            {
       
                consumer.Subscribe(KafkaTopic);

                // Handle Cancel Keypress 
                var cancelled = false;
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cancelled = true;
                };

                Console.WriteLine("Ctrl-C to exit.");

                // Poll for messages
                while (!cancelled)
                {
                    consumer.Close();
                }

            }
        }
    }
}
