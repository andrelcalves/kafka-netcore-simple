# kafka-netcore-simple
Aplicações simples para mensageria em netcore

1. Vamos montar um ambiente DEV Kafka com Docker Compose utilizando imagens da empresa Confluent, vamos  também utilizar em nossas aplicações console(producer/consuemer) o pacote/biblioteca confluent-kafka-dotnet, disponibilizada também pela Confluent; 

2. Nesse exemplo simples vamos utilizar duas APIs do Apache Kafka que serão abstraídos pela biblioteca da confluent:

* 2.1 Producer API para publicar (escrever) uma stream de eventos para um ou mais topicos no Kafka;
* 2.2 Consumer API para consumir (ler) um ou mais topicos e processar essa stream de eventos gerados pelo(s) producer(s);

2. Criei duas aplicações console simples uma para produzir as mensagens (simpleProducer) e outra console para cosumo (simpleConsumer);
   ``` dotnet new console -n simpleProducer ```
   ``` dotnet new console -n simpeConsumer ```

3. Para trabalhar com Kafka em .Net Core vamos adicionar o pacote Confluent.Kafka via nutget ```dotnet add package Confluent.Kafka```

4. Se você tem dúvida de como subir o docker composo, ou não se recordar basta executar o comando: ``` doceker-compose up ```

5. Nesse exemplo simples, o producer precisa ser executado primeiro para poder existir
o tópico no kafka, caso contrário, o consumer não vai encontrar o tópico definido;

