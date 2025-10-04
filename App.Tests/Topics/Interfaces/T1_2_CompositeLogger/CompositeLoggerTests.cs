using System;
using System.Linq;
using App.Topics.Interfaces.T1_2_CompositeLogger;
using FluentAssertions;
using Xunit;

namespace App.Tests.Topics.Interfaces.T1_2_CompositeLogger;

[Trait("Category", "*")]
public class CompositeLoggerTests
{
    [Fact]
    public void MemoryLogger_ShouldStoreMessages()
    {
        var m = new MemoryLogger();
        m.Log("a");
        m.Warn("b");
        m.Error("c");
        m.Info.Should().Equal("a");
        m.Warnings.Should().Equal("b");
        m.Errors.Should().Equal("c");
    }

    [Theory]
    [InlineData(null)]
    public void MemoryLogger_NullMessage_ShouldThrow(string? msg)
    {
        var m = new MemoryLogger();
        Action a1 = () => m.Log(msg!);
        Action a2 = () => m.Warn(msg!);
        Action a3 = () => m.Error(msg!);
        a1.Should().Throw<ArgumentNullException>();
        a2.Should().Throw<ArgumentNullException>();
        a3.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CompositeLogger_ShouldFanOutCalls()
    {
        var l1 = new MemoryLogger();
        var l2 = new MemoryLogger();
        var composite = new CompositeLogger(new ILogger?[] { l1, null, l2 });

        composite.Log("x");
        composite.Warn("y");
        composite.Error("z");

        l1.Info.Should().Equal("x");
        l2.Info.Should().Equal("x");
        l1.Warnings.Should().Equal("y");
        l2.Warnings.Should().Equal("y");
        l1.Errors.Should().Equal("z");
        l2.Errors.Should().Equal("z");
    }

    [Fact]
    public void CompositeLogger_NullCollection_ShouldThrow()
    {
        Action act = () => new CompositeLogger(null!);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void CompositeLogger_Empty_ShouldNotThrowAndDoNothing()
    {
        var composite = new CompositeLogger(Enumerable.Empty<ILogger>());
        composite.Invoking(c => c.Log(""))
                 .Should().NotThrow();
    }
}
