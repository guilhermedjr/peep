using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Confluent.Kafka.SyncOverAsync;
namespace Peep.EventBus.Kafka;

public class KafkaConnection
{
    private readonly ProducerConfig _producerConfiguration;
    private readonly SchemaRegistryConfig _schemaRegistryConfiguration;
    private readonly ConsumerConfig _consumerConfiguration;
    private readonly AvroSerializerConfig _avroSerializerConfiguration;
    private object _producerBuilder;

    public KafkaConnection(ProducerConfig producerConfig, ConsumerConfig consumerConfig,
        SchemaRegistryConfig schemaRegistryConfig, AvroSerializerConfig avroSerializerConfig)
    {
        _producerConfiguration = producerConfig ?? throw new ArgumentNullException(nameof(producerConfig));
        _consumerConfiguration = consumerConfig ?? throw new ArgumentNullException(nameof(consumerConfig));
        _schemaRegistryConfiguration = schemaRegistryConfig ?? throw new ArgumentNullException(nameof(schemaRegistryConfig));
        _avroSerializerConfiguration = avroSerializerConfig ?? throw new ArgumentNullException(nameof(avroSerializerConfig));
    }

    public IProducer<Null, T> BuildProducer<T>()
    {
        if (_producerBuilder == null)
        {
            var schemaRegistry = new CachedSchemaRegistryClient(_schemaRegistryConfiguration);
            _producerBuilder = new ProducerBuilder<Null, T>(_producerConfiguration)
                .SetValueSerializer(new AvroSerializer<T>(schemaRegistry))
                .Build();
        }

        return (IProducer<Null, T>)_producerBuilder;
    }

    public IConsumer<Null, T> BuildConsumer<T>()
    {
        var schemaRegistry = new CachedSchemaRegistryClient(_schemaRegistryConfiguration);
        var consumer = new ConsumerBuilder<Null, T>(_consumerConfiguration)
            .SetValueDeserializer(new AvroDeserializer<T>(schemaRegistry).AsSyncOverAsync())
            .Build();

        return consumer;
    }
}