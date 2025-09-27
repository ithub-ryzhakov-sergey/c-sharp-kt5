namespace App.Topics.InterfaceReferences.T2_1_ZooSpeak

{
    public class ZooUtils
    {
        public static string[] SpeakAll(IEnumerable<IAnimal> animals)
        {
            if (animals == null)
                throw new ArgumentNullException(nameof(animals));

            foreach (var animal in animals)
            {
                if (animal == null)
                    throw new ArgumentNullException(nameof(animals), "нал");
            }

            return animals.Select(a => a.Speak()).ToArray();
        }
    }
}