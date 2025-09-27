namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public interface IPersonDirectory
{
    int Count { get; }
    string this[int id] { get; set; }
}

public class InMemoryPersonDirectory : IPersonDirectory
{
    private Dictionary<int, string> _storage = new Dictionary<int, string>();

    public int Count => _storage.Count;

    public string this[int id]
    {
        get
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "OutOfRangeException");
            if (!_storage.TryGetValue(id, out var name))
                throw new KeyNotFoundException($"ID {id} нет данных");
            return name;
        }
        set
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "OutOfRangeException");
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "нет данных");

            _storage[id] = value;
        }
    }
}