//using System;
//using App.Topics.InterfaceReferences.T2_2_VariancePipeline;
//using FluentAssertions;
//using Xunit;

//namespace App.Tests.Topics.InterfaceReferences.T2_2_VariancePipeline;

//[Trait("Category", "*")]
//public class VarianceTests
//{
//    private class Animal { }
//    private class Dog : Animal { public override string ToString() => "Dog"; }

//    [Fact]
//    public void Producer_ShouldProduceValues()
//    {
//        var p = new Producer<int>(() => 42);
//        p.Produce().Should().Be(42);
//    }

//    [Fact]
//    public void Collector_ShouldCollectItems()
//    {
//        var c = new Collector<string>();
//        c.Consume("a");
//        c.Consume("b");
//        c.Items.Should().Equal("a", "b");
//    }

//    [Fact]
//    public void Adapter_ShouldRunPipeline_CountTimes()
//    {
//        int i = 0;
//        var p = new Producer<int>(() => ++i);
//        var c = new Collector<string>();
//        var adapter = new Adapter<int, string>(p, c, x => $"#{x}");
//        adapter.Run(3);
//        c.Items.Should().Equal("#1", "#2", "#3");
//    }

//    [Fact]
//    public void Adapter_NegativeCount_ShouldThrow()
//    {
//        var p = new Producer<int>(() => 0);
//        var c = new Collector<int>();
//        var adapter = new Adapter<int, int>(p, c, x => x);
//        adapter.Invoking(a => a.Run(-1)).Should().Throw<ArgumentOutOfRangeException>();
//    }

//    [Fact]
//    public void Variance_ShouldAllowCompatibleTypes()
//    {
//        IProducer<Dog> dogProducer = new Producer<Dog>(() => new Dog());
//        IProducer<Animal> animalProducer = dogProducer; // out T

//        IConsumer<Animal> animalConsumer = new Collector<Animal>();
//        IConsumer<Dog> dogConsumer = animalConsumer; // in T

//        var adapter = new Adapter<Dog, Animal>(dogProducer, animalConsumer, d => d);
//        adapter.Run(2);
//        (animalConsumer as Collector<Animal>)!.Items.Should().HaveCount(2);
//    }
//}
