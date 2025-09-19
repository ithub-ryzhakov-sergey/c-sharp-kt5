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
    public Producer(Func<T> factory)
    {
        // TODO: сохранить фабрику, проверить на null
        throw new NotImplementedException();
    }

    public T Produce()
    {
        // TODO: вернуть значение через фабрику
        throw new NotImplementedException();
    }
}

public class Collector<T> : IConsumer<T>
{
    public List<T> Items { get; } = new();

    public void Consume(T item)
    {
        // TODO: добавить элемент в Items
        throw new NotImplementedException();
    }
}

public class Adapter<TFrom, TTo>
{
    public Adapter(IProducer<TFrom> producer, IConsumer<TTo> consumer, Func<TFrom, TTo> mapper)
    {
        // TODO: сохранить зависимости, проверить на null
        throw new NotImplementedException();
    }

    public void Run(int count)
    {
        // TODO: если count < 0 — ArgumentOutOfRangeException
        // count раз вызвать Produce, затем mapper, затем Consume
        throw new NotImplementedException();
    }
}
