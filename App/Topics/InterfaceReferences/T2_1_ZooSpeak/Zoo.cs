using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak
{
    public interface IAnimal
    {
        string Speak();
    }

    public class Dog : IAnimal
    {
        public string Speak() => "woof";
    }

    public class Cat : IAnimal
    {
        public string Speak() => "meow";
    }

    public class Duck : IAnimal
    {
        public string Speak() => "quack";
    }
}