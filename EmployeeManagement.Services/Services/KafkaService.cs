using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using EmployeeManagement.Services.Configs;
using EmployeeManagement.Services.Models;
using Microsoft.Extensions.Options;

namespace EmployeeManagement.Services.Services;

public class KafkaService : IKafkaService, IDisposable
{
    private IProducer<Null, OperationType> _producer;
    private CachedSchemaRegistryClient _schemaRegistry;

    public KafkaService(IOptions<KafkaOptions> kafkaOptions)
    {
        var config = new ProducerConfig 
        {
            BootstrapServers = kafkaOptions.Value.BootstrapServers,
            ClientId = kafkaOptions.Value.ClientId,
            Acks = Enum.Parse<Acks>(kafkaOptions.Value.Acks, true)
        };
        var schemaRegistryConfig = new SchemaRegistryConfig 
        {
            Url = kafkaOptions.Value.Url
        };
        _schemaRegistry = new CachedSchemaRegistryClient(schemaRegistryConfig);
        _producer = new ProducerBuilder<Null, OperationType>(config)
            .SetValueSerializer(new JsonSerializer<OperationType>(_schemaRegistry))
            .Build();
    }
    
    public async Task ProduceToKafkaAsync(string topic, OperationType operationType)
    {
        try 
        {
            var deliveryReport = await _producer
                .ProduceAsync(topic, new Message<Null, OperationType> { Value = operationType });

            Console.WriteLine($"Delivered to '{deliveryReport.TopicPartitionOffset}'");
        }
        catch (ProduceException<Null, OperationType> e) 
        {
            Console.WriteLine($"Failed to deliver message: {e.Message} [{e.Error.Code}]");
            throw;
        }
    }
    
    public void Dispose()
    {
        _producer?.Dispose();
        _schemaRegistry?.Dispose();
    }
}