namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak;

public class ZooUtils
{
    public static string[] SpeakAll(IEnumerable<IAnimal> animals)
    {
        if (animals == null) {
            throw new ArgumentNullException();
        }
        List<string> res = new List<string>();
        foreach (var item in animals)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            res.Add(item.Speak());
        }
        return res.ToArray();
    }
}