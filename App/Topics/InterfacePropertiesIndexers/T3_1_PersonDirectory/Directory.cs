using System;
using System.Collections.Generic;

namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public interface IPersonDirectory
{
    int Count { get; }
    string this[int id] { get; set; }
}

public class InMemoryPersonDirectory : IPersonDirectory
{
    private readonly Dictionary<int, string> _directory;

    public InMemoryPersonDirectory()
    {
        _directory = new Dictionary<int, string>();
    }

    public int Count => _directory.Count;

    public string this[int id]
    {
        get
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (_directory.TryGetValue(id, out string name))
                return name;

            throw new KeyNotFoundException();
        }
        set
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            _directory[id] = value;
        }
    }
}