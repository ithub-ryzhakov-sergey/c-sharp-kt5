// Topic 3: Interface Properties and Indexers
// Task T3.1 PersonDirectory (обязательная)
// Реализуйте интерфейс IPersonDirectory и класс InMemoryPersonDirectory согласно README.

namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public interface IPersonDirectory
{
    int Count { get; }
    string this[int id] { get; set; }
}
public class InMemoryPersonDirectory : IPersonDirectory
{
    private Dictionary<int, string> storage = new Dictionary<int, string>();
    public int Count
    {
        get{ return storage.Count; }

    }
    public string this[int id]
    {
        get
        {
            if (id < 0) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            if (storage.ContainsKey(id)) {
                return storage[id];
            }
            else {
                throw new KeyNotFoundException(nameof(id));
            }
        }
        set
        {
            if (id < 0) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException(nameof(value));
            }

            storage[id] = value;
        }
    }
}