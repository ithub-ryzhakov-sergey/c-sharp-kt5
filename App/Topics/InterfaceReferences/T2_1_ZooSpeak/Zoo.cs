using System;
using System.Collections.Generic;
using System.Linq;

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

public static class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        if (animals == null)
            throw new ArgumentNullException(nameof(animals));
        if (animals.Any(a => a == null))
            throw new ArgumentNullException(nameof(animals));
        return animals.Select(a => a.Speak()).ToArray();
    }
}