using System;
using App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;
using FluentAssertions;
using Xunit;

namespace App.Tests.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public class PersonDirectoryTests
{
    [Fact]
    public void NewDirectory_ShouldBeEmpty()
    {
        IPersonDirectory dir = new InMemoryPersonDirectory();
        dir.Count.Should().Be(0);
    }

    [Fact]
    public void Set_Get_ShouldRoundtrip()
    {
        IPersonDirectory dir = new InMemoryPersonDirectory();
        dir[0] = "Alice";
        dir[1] = "Bob";
        dir.Count.Should().Be(2);
        dir[0].Should().Be("Alice");
        dir[1].Should().Be("Bob");
    }

    [Fact]
    public void Get_UnknownId_ShouldThrow()
    {
        IPersonDirectory dir = new InMemoryPersonDirectory();
        Action act = () => { var _ = dir[42]; };
        act.Should().Throw<KeyNotFoundException>();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void NegativeId_ShouldThrow(int id)
    {
        IPersonDirectory dir = new InMemoryPersonDirectory();
        Action g = () => { var _ = dir[id]; };
        Action s = () => dir[id] = "X";
        g.Should().Throw<ArgumentOutOfRangeException>();
        s.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void NullOrEmptyName_ShouldThrow(string? name)
    {
        IPersonDirectory dir = new InMemoryPersonDirectory();
        Action act = () => dir[0] = name!;
        act.Should().Throw<ArgumentNullException>();
    }
}
