namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public static class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        if (animals == null)
            throw new ArgumentNullException(nameof(animals));

        if (animals.Any(animal => animal == null))
            throw new ArgumentNullException(nameof(animals), "Collection contains null elements");

        return animals.Select(animal => animal.Speak()).ToArray();
    }
}