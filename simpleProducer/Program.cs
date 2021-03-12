using System;
using Serilog;
using System.Net;
using Confluent.Kafka;

namespace simpleProducer
{
    class Program
    {
        const string KafkaServer = "127.0.0.1:9092";
        const string KafkaTopic  = "testTopic";

        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateLogger();
            logger.Information("Testando o envio de mensagens com Kafka");

            if (args.Length < 10)
            {
                logger.Error(
                    "Informe ao menos 10 parâmetros: " +
                    "contendo as mensagens a serem enviadas para fila" +
                    "que serão enviadas a um Topic no Kafka...");
                return;
            }

            var producerConfig = new ProducerConfig{
                BootstrapServers = KafkaServer,
                ClientId = Dns.GetHostName()
            };

            using (var producer = new ProducerBuilder<Null, string>(producerConfig).Build())
            {
                // Send 10 messages to the topic
                for (int i = 0; i < 10; i++)
                {
                    var result = producer.ProduceAsync(KafkaTopic,  new Message<Null,string> { Value = args[i] }).GetAwaiter().GetResult();
                    Console.WriteLine($"Event {i} sent on Partition: {result.Partition} with Offset: {result.Offset}");
                }
            }
        }
    }
}
