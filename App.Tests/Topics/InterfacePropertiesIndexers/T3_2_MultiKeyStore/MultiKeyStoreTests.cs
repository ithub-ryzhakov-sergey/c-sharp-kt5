// using System;
// using App.Topics.InterfacePropertiesIndexers.T3_2_MultiKeyStore;
// using FluentAssertions;
// using Xunit;
//
// namespace App.Tests.Topics.InterfacePropertiesIndexers.T3_2_MultiKeyStore;
//
// [Trait("Category","*")]
// public class MultiKeyStoreTests
// {
//     [Fact]
//     public void SetAndGet_ById_And_ByKey_ShouldBeConsistent()
//     {
//         IKeyStore store = new InMemoryKeyStore();
//         store[0] = "zero";
//         store["one"] = "1";
//
//         store[0].Should().Be("zero");
//         store["one"].Should().Be("1");
//         store.Count.Should().Be(2);
//
//         // Обновление
//         store[0] = "ZERO";
//         store["one"] = "ONE";
//         store[0].Should().Be("ZERO");
//         store["one"].Should().Be("ONE");
//     }
//
//     [Fact]
//     public void Get_Unknown_ShouldThrow()
//     {
//         IKeyStore store = new InMemoryKeyStore();
//         Action g1 = () => { var _ = store[0]; };
//         Action g2 = () => { var _ = store["x"]; };
//         g1.Should().Throw<KeyNotFoundException>();
//         g2.Should().Throw<KeyNotFoundException>();
//     }
//
//     [Theory]
//     [InlineData(-1)]
//     [InlineData(-5)]
//     public void NegativeId_ShouldThrow(int id)
//     {
//         IKeyStore store = new InMemoryKeyStore();
//         Action g = () => { var _ = store[id]; };
//         Action s = () => store[id] = "x";
//         g.Should().Throw<ArgumentOutOfRangeException>();
//         s.Should().Throw<ArgumentOutOfRangeException>();
//     }
//
//     [Theory]
//     [InlineData(null)]
//     [InlineData("")]
//     [InlineData("   ")]
//     public void NullOrEmptyKey_ShouldThrow(string? key)
//     {
//         IKeyStore store = new InMemoryKeyStore();
//         Action g = () => { var _ = store[key!]; };
//         Action s = () => store[key!] = "val";
//         g.Should().Throw<ArgumentNullException>();
//         s.Should().Throw<ArgumentNullException>();
//     }
//
//     [Theory]
//     [InlineData(null)]
//     [InlineData("")]
//     [InlineData("   ")]
//     public void NullOrEmptyValue_ShouldThrow(string? value)
//     {
//         IKeyStore store = new InMemoryKeyStore();
//         Action s1 = () => store[0] = value!;
//         Action s2 = () => store["a"] = value!;
//         s1.Should().Throw<ArgumentNullException>();
//         s2.Should().Throw<ArgumentNullException>();
//     }
// }
