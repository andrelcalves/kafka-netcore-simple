# kafka-netcore-simple
Aplicações simples para mensageria em netcore

1. ambiente dev kafka com Docker Compose utilizando imagens da empresa Confluent;
2. criei duas aplicações console simples uma para produzir as msg (simpleProducer) e outra console para cosumo (simpleConsumer);
   ``dotnet new console -n simpleProducer´´
   ``dotnet new console -n simpeConsumer´´

3. para trabalhar com kafka em .net core precisamos vamos adicionar os pacotes via nutget ``dotnet add package Confluent.Kafka´´