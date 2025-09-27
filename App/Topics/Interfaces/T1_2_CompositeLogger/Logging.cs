// Topic 1: Interfaces
// Task T1.2 CompositeLogger (*)
// Реализуйте интерфейс ILogger и классы MemoryLogger и CompositeLogger согласно README.
// Оставьте NotImplementedException — тесты должны падать, пока студент не реализует решение.

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Topics.Interfaces.T1_2_CompositeLogger;

public interface ILogger 
{
    void Log(string message); void Warn(string message); void Error(string message);
}

public class MemoryLogger : ILogger
{
    public List<string> Info { get; } = new List<string>();
    public List<string> Warnings { get; } = new List<string>();
    public List<string> Errors { get; } = new List<string>();

    public void Log(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Info.Add(message);
    }

    public void Warn(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Warnings.Add(message);
    }
    public void Error(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Errors.Add(message);
    }
}

public class CompositeLogger : ILogger 
{   
    private readonly IEnumerable<ILogger> _loggers;

    public CompositeLogger(IEnumerable<ILogger> loggers)
    {
        if (loggers == null) throw new ArgumentNullException(nameof(loggers));

        var validLogger = new List<ILogger>();
        foreach(var logger in loggers)
        {
            if (logger != null)
            {
                validLogger.Add(logger);
            }
        }

        _loggers = validLogger;
    }

    public void Log(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        foreach (var logger in _loggers)
        {
            logger.Log(message);
        }
    }

    public void Warn(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        foreach (var logger in _loggers)
        {
            logger.Warn(message);
        }
    }
    public void Error(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        foreach (var logger in _loggers)
        {
            logger.Error(message);
        }
    }
}

