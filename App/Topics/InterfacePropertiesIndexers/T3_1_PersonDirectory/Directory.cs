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
    private readonly Dictionary<int, string> _storage = new Dictionary<int, string>();

    public int Count => _storage.Count;

    public string this[int id]
    {
        get
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "аутофренгеексептионе");
            if (!_storage.TryGetValue(id, out var name))
                throw new KeyNotFoundException($"ID {id} not found.");
            return name!;
        }
        set
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "аутофренгеексептионе");
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "нет данных");

            _storage[id] = value;
        }
    }
}
