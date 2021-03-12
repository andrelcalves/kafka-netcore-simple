using System;
using Confluent.Kafka;
using Serilog;
using System.Threading;

namespace simpleConsumer
{
    class Program
    {
        const string KafkaServer = "127.0.0.1:9092";
        const string KafkaTopic = "testTopic";

        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
            logger.Information("Testando o consumo de mensagens com Kafka");

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
                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };

                Console.WriteLine("Ctrl-C to exit.");

                try
                {
                    while (true)
                    {
                        var cr = consumer.Consume(cts.Token);
                        logger.Information(
                            $"Mensagem lida: {cr.Message.Value}");
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                    logger.Warning("Cancelada a execução do Consumer...");
                }

            }
        }
    }
}
