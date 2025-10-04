using System;
using System.Collections.Generic;

namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory
{
    public interface IPersonDirectory
    {
        int Count { get; }
        string this[int id] { get; set; }
    }

    public class InMemoryPersonDirectory : IPersonDirectory
    {
        private readonly Dictionary<int, string> _entries = new Dictionary<int, string>();

        public int Count => _entries.Count;

        public string this[int id]
        {
            get
            {
                if (id < 0)
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be non-negative.");

                if (_entries.TryGetValue(id, out string value))
                    return value;

                throw new KeyNotFoundException($"No entry found for ID {id}.");
            }
            set
            {
                if (id < 0)
                    throw new ArgumentOutOfRangeException(nameof(id), "ID must be non-negative.");

                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                string trimmed = value.Trim();
                if (trimmed.Length == 0)
                    throw new ArgumentNullException(nameof(value), "Name cannot be null, empty, or whitespace.");

                _entries[id] = trimmed; // или просто value, если не требуется обрезать пробелы
                // Но тест проверяет именно запрет пустых/пробельных строк → исключение
                // Поэтому мы бросаем исключение, а не сохраняем
            }
        }
    }
}