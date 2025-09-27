// Topic 3: Interface Properties and Indexers
// Task T3.1 PersonDirectory (обязательная)
// Реализуйте интерфейс IPersonDirectory и класс InMemoryPersonDirectory согласно README.

using System.ComponentModel;

namespace App.Topics.InterfacePropertiesIndexers.T3_1_PersonDirectory;

public interface IPersonDirectory
{
    int Count { get; }
    string this[int id] { get; set; }
}

public class InMemoryPersonDirectory : IPersonDirectory
{
    private readonly Dictionary<int, string> _persons = new Dictionary<int, string>();
    public int Count => _persons.Count;

    public string this[int id]
    {
        get
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _persons[id];
        }

        set
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            //if (value == null || value == "" || value.Trim() == "")
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException();

            _persons[id] = value;
        }
    }
}