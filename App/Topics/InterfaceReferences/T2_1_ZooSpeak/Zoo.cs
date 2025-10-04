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

    public static class ZooUtils
    {
        public static string[] SpeakAll(IEnumerable<IAnimal> animals)
        {
            if (animals == null)
                throw new ArgumentNullException(nameof(animals));

            // Преобразуем в список, чтобы проверить null-элементы и сохранить порядок
            var animalList = animals.ToList();

            // Проверяем наличие null-элементов
            if (animalList.Any(a => a == null))
                throw new ArgumentNullException(nameof(animals), "Collection contains null elements.");

            // Возвращаем массив звуков в том же порядке
            return animalList.Select(a => a.Speak()).ToArray();
        }
    }
}