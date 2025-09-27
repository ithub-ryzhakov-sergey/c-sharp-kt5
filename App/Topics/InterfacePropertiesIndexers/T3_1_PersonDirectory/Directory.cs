// Topic 3: Interface Properties and Indexers
// Task T3.1 PersonDirectory (обязательная)
// Реализуйте интерфейс IPersonDirectory и класс InMemoryPersonDirectory согласно README.

using System.Security.Cryptography.X509Certificates;

namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public interface IPersonDirectory
{
    int Count { get; }
    string this[int id] { get; set; }
}

public class InMemoryPersonDirectory : IPersonDirectory
{
    private Dictionary<int, string> Storage = new Dictionary<int, string>();
    public int Count
    {
        get
        {
            return Storage.Count;
        }
     }
    public string this[int id]
    {
        get
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!Storage.ContainsKey(id))
            {
                throw new KeyNotFoundException();
            }
            return Storage[id];
        }
        set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentNullException();
            }

            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Storage.Add(id, value);
        }
    }
}