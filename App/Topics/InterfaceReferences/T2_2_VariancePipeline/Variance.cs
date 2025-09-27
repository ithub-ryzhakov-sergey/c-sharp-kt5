using System;
using System.Collections.Generic;

namespace App.Topics.InterfaceReferences.T2_2_VariancePipeline
{
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
        private readonly Func<T> _producerFunc;

        public Producer(Func<T> producerFunc)
        {
            _producerFunc = producerFunc ?? throw new ArgumentNullException(nameof(producerFunc));
        }

        public T Produce() => _producerFunc();
    }

    public class Collector<T> : IConsumer<T>
    {
        public List<T> Items { get; } = new List<T>();

        public void Consume(T item)
        {
            Items.Add(item);
        }
    }

    public class Adapter<TIn, TOut>
    {
        private readonly IProducer<TIn> _producer;
        private readonly IConsumer<TOut> _consumer;
        private readonly Func<TIn, TOut> _adapterFunc;

        public Adapter(IProducer<TIn> producer, IConsumer<TOut> consumer, Func<TIn, TOut> adapterFunc)
        {
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
            _consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            _adapterFunc = adapterFunc ?? throw new ArgumentNullException(nameof(adapterFunc));
        }

        public void Run(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative");

            for (int i = 0; i < count; i++)
            {
                var input = _producer.Produce();
                var output = _adapterFunc(input);
                _consumer.Consume(output);
            }
        }
    }
}