using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Topics.InterfacePropertiesIndexers.T3_2_MultiKeyStore
{
    public interface IKeyStore
    {
        int Count { get; }
        string this[int id] { get; set; }
        string this[string key] { get; set; }
    }

    public class InMemoryKeyStore : IKeyStore
    {
        private readonly Dictionary<int, string> _idStorage = new Dictionary<int, string>();
        private readonly Dictionary<string, string> _keyStorage = new Dictionary<string, string>();
        private int _nextId = 0;

        public int Count => _idStorage.Count;

        public string this[int id]
        {
            get
            {
                if (id < 0)
                    throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");

                if (_idStorage.TryGetValue(id, out string value))
                    return value;

                throw new KeyNotFoundException($"Id {id} not found");
            }
            set
            {
                if (id < 0)
                    throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Value cannot be null, empty or whitespace");

                _idStorage[id] = value;
            }
        }

        public string this[string key]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentNullException(nameof(key), "Key cannot be null, empty or whitespace");

                if (_keyStorage.TryGetValue(key, out string value))
                    return value;

                throw new KeyNotFoundException($"Key '{key}' not found");
            }
            set
            {
                if (string.IsNullOrWhiteSpace(key))
                    throw new ArgumentNullException(nameof(key), "Key cannot be null, empty or whitespace");

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value), "Value cannot be null, empty or whitespace");

                _keyStorage[key] = value;

                // Если ключ уже связан с id, обновляем значение по id
                var existingId = _idStorage.FirstOrDefault(x => x.Value == _keyStorage[key]).Key;
                if (existingId != 0 || _idStorage.ContainsKey(0))
                {
                    _idStorage[existingId] = value;
                }
                else
                {
                    // Создаем новую запись с id
                    _idStorage[_nextId] = value;
                    _nextId++;
                }
            }
        }
    }
}