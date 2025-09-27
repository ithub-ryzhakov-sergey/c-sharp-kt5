// Topic 2: Interface References
// Task T2.1 ZooSpeak (обязательная)
// Реализуйте интерфейс IAnimal, классы животных и функцию SpeakAll согласно README.

namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public interface IAnimal
{
    public string Speak();
}
public class Dog : IAnimal
{
    public string Speak()
    {
        return "woof";
    }
}
public class Cat : IAnimal
{
    public string Speak()
    {
        return "meow";
    }
}
public class Duck : IAnimal
{
    public string Speak()
    {
        return "quack";
    }
}
