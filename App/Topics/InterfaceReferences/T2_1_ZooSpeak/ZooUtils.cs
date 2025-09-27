namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        List<string> sounds = new List<string>();
        if (animals == null)
        {
            throw new ArgumentNullException();
        }
        foreach (var animal in animals)
        {
            if (animal == null)
            {
                throw new ArgumentNullException();
            }
            sounds.Add(animal.Speak());
        }
        return sounds.ToArray();
    }
}