using Confluent.Kafka;

const string topic = "chat-room";

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Chat publisher. Type a message and press Enter to send. Type 'exit' to quit.");

string? line;
while ((line = Console.ReadLine()) is not null && line != "exit")
{
    var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = line });
    Console.WriteLine($"Sent to {result.TopicPartitionOffset}");
}
