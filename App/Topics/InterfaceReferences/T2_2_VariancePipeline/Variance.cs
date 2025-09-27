// Topic 2: Interface References
// Task T2.2 VariancePipeline (*)
// Реализуйте интерфейсы с вариативностью и классы-адаптеры согласно README.

namespace App.Topics.InterfaceReferences.T2_2_VariancePipeline;

public interface IProducer<out T>
{
    T Produce();
}

public interface IConsumer<in T>
{
    void Consume(T item);
}

public class Producer<T> : IProducer<T>
{

    private readonly Func<T> _factory;

    public Producer(Func<T> factory)
    {
        // TODO: сохранить фабрику, проверить на null
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    public T Produce()
    {
        // TODO: вернуть значение через фабрику
        return _factory();
    }
}

public class Collector<T> : IConsumer<T>
{
    public List<T> Items { get; } = new();

    public void Consume(T item)
    {
        // TODO: добавить элемент в Items
        Items.Add(item);
    }
}

public class Adapter<TFrom, TTo>
{

    private readonly IProducer<TFrom> _producer;
    private readonly IConsumer<TTo> _consumer;
    private readonly Func<TFrom, TTo> _mapper;

    public Adapter(IProducer<TFrom> producer, IConsumer<TTo> consumer, Func<TFrom, TTo> mapper)
    {
        // TODO: сохранить зависимости, проверить на null
        _producer = producer ?? throw new ArgumentNullException(nameof(producer));
        _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public void Run(int count)
    {
        // TODO: если count < 0 — ArgumentOutOfRangeException
        // count раз вызвать Produce, затем mapper, затем Consume
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "ArgumentOutOfRangeException");

        for (int i = 0; i < count; i++)
        {
            TFrom produced = _producer.Produce();
            TTo mapped = _mapper(produced);
            _consumer.Consume(mapped);
        }
    }
}
