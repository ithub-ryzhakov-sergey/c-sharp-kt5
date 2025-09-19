// using System;
// using App.Topics.Interfaces.T1_1_BasicShapes;
// using FluentAssertions;
// using Xunit;
//
// namespace App.Tests.Topics.Interfaces.T1_1_BasicShapes;
//
// public class ShapesTests
// {
//     [Fact]
//     public void Rectangle_Area_ShouldBeWidthTimesHeight()
//     {
//         var rect = new Rectangle(3, 4);
//         rect.Name.Should().Be("Rectangle");
//         rect.Width.Should().Be(3);
//         rect.Height.Should().Be(4);
//         rect.Area().Should().BeApproximately(12, 1e-6);
//     }
//
//     [Theory]
//     [InlineData(0, 1)]
//     [InlineData(1, 0)]
//     [InlineData(-1, 2)]
//     [InlineData(2, -1)]
//     public void Rectangle_InvalidArgs_ShouldThrow(double w, double h)
//     {
//         Action act = () => new Rectangle(w, h);
//         act.Should().Throw<ArgumentOutOfRangeException>();
//     }
//
//     [Fact]
//     public void Circle_Area_ShouldBePiR2()
//     {
//         var c = new Circle(2);
//         c.Name.Should().Be("Circle");
//         c.Radius.Should().Be(2);
//         c.Area().Should().BeApproximately(Math.PI * 4, 1e-6);
//     }
//
//     [Theory]
//     [InlineData(0)]
//     [InlineData(-1)]
//     public void Circle_InvalidArgs_ShouldThrow(double r)
//     {
//         Action act = () => new Circle(r);
//         act.Should().Throw<ArgumentOutOfRangeException>();
//     }
// }
