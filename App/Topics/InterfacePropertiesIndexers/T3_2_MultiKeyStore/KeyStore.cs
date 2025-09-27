// Topic 3: Interface Properties and Indexers
// Task T3.2 MultiKeyStore (*)
// Реализуйте интерфейс IKeyStore и класс InMemoryKeyStore согласно README.

namespace App.Topics.InterfacePropertiesIndexers.T3_2_MultiKeyStore;

public interface IKeyStore
{
    int Count { get; }
    string this[int id] { get; set; }
    string this[string key] { get; set; }
}






public class InMemoryKeyStore : IKeyStore
{
    private readonly Dictionary<int, string> _idToValue = new Dictionary<int, string>();
    private readonly Dictionary<string, int> _keyToId = new Dictionary<string, int>();

    public int Count => _idToValue.Count;

    public string this[int id]
    {
        get
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "неверные");
            if (!_idToValue.TryGetValue(id, out var value))
                throw new KeyNotFoundException($"айди {id} не найден");
            return value!;
        }
        set
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "неверные");
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "нет данных");
            if (_idToValue.ContainsKey(id))
            {
                var oldValue = _idToValue[id];
                if (oldValue != value)
                {
                    _keyToId.Remove(oldValue);
                    _keyToId[value] = id;
                }
                _idToValue[id] = value;
            }
            else
            {
                _idToValue[id] = value;
                _keyToId[value] = id;
            }
        }
    }

    public string this[string key]
    {
        get
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (!_keyToId.TryGetValue(key, out var id))
                throw new KeyNotFoundException($"ключ '{key}' не найден");
            return this[id];
        }
        set
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));
            if (_keyToId.TryGetValue(key, out var id))
            {
                this[id] = value;
            }
            else
            {
                int newId = Count;
                _idToValue[newId] = value;
                _keyToId[key] = newId;
            }
        }
    }
}