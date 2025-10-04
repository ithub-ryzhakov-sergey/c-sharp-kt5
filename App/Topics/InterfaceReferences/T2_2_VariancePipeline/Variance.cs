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
        private readonly Func<T> factory;

        public Producer(Func<T> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public T Produce()
        {
            return factory();
        }
    }

    public class Collector<T> : IConsumer<T>
    {
        public List<T> Items { get; } = new List<T>();

        public void Consume(T item)
        {
            Items.Add(item);
        }
    }

    public class Adapter<TFrom, TTo>
    {
        private readonly IProducer<TFrom> producer;
        private readonly IConsumer<TTo> consumer;
        private readonly Func<TFrom, TTo> transformer;

        public Adapter(IProducer<TFrom> producer, IConsumer<TTo> consumer, Func<TFrom, TTo> transformer)
        {
            this.producer = producer ?? throw new ArgumentNullException(nameof(producer));
            this.consumer = consumer ?? throw new ArgumentNullException(nameof(consumer));
            this.transformer = transformer ?? throw new ArgumentNullException(nameof(transformer));
        }

        public void Run(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");

            for (int i = 0; i < count; i++)
            {
                TFrom produced = producer.Produce();
                TTo transformed = transformer(produced);
                consumer.Consume(transformed);
            }
        }
    }
}