using System;
using System.Linq;
using App.Topics.InterfaceReferences.T2_1_ZooSpeak;
using FluentAssertions;
using Xunit;

namespace App.Tests.Topics.InterfaceReferences.T2_1_ZooSpeak;

public class ZooSpeakTests
{
    [Fact]
    public void SpeakAll_ShouldReturnSoundsInOrder()
    {
        IAnimal[] animals = { new Dog(), new Cat(), new Duck() };
        var sounds = ZooUtils.SpeakAll(animals);
        sounds.Should().Equal("woof", "meow", "quack");
    }

    [Fact]
    public void SpeakAll_Empty_ShouldReturnEmptyArray()
    {
        var sounds = ZooUtils.SpeakAll(Array.Empty<IAnimal>());
        sounds.Should().BeEmpty();
    }

    [Fact]
    public void SpeakAll_NullCollection_ShouldThrow()
    {
        Action act = () => ZooUtils.SpeakAll(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void SpeakAll_NullItem_ShouldThrow()
    {
        IAnimal?[] animals = { new Dog(), null };
        Action act = () => ZooUtils.SpeakAll(animals!);
        act.Should().Throw<ArgumentNullException>();
    }
}
