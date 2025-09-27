namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        if (animals == null) throw new ArgumentNullException(nameof(animals));
        if (animals.Any(a => a == null)) throw new ArgumentNullException(nameof(animals));

        return animals.Select(a => a.Speak()).ToArray();
    }
}