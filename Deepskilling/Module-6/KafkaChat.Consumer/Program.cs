using Confluent.Kafka;

const string topic = "chat-room";

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = $"chat-client-{Guid.NewGuid()}",
    AutoOffsetReset = AutoOffsetReset.Latest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe(topic);

Console.WriteLine("Chat consumer. Listening for messages, press Ctrl+C to quit.");

var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

try
{
    while (!cts.IsCancellationRequested)
    {
        var result = consumer.Consume(cts.Token);
        Console.WriteLine($"[{result.TopicPartitionOffset}] {result.Message.Value}");
    }
}
catch (OperationCanceledException)
{
}
finally
{
    consumer.Close();
}
