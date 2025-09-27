namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public static class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        if (animals == null)
            throw new ArgumentNullException();

        var lst = new List<string>();

        foreach (var animal in animals)
        {
            if (animal == null)
                throw new ArgumentNullException();

            lst.Add(animal.Speak());
        }

        return lst.ToArray();
    }
}