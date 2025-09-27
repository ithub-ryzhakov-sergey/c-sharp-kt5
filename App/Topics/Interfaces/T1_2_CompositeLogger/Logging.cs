// Topic 1: Interfaces
// Task T1.2 CompositeLogger (*)
// Реализуйте интерфейс ILogger и классы MemoryLogger и CompositeLogger согласно README.
// Оставьте NotImplementedException — тесты должны падать, пока студент не реализует решение.

namespace App.Topics.Interfaces.T1_2_CompositeLogger


{
    public interface ILogger
    {
        void Log(string message);
        void Warn(string message);
        void Error(string message);
    }

    public class MemoryLogger : ILogger
    {
        private readonly List<string> _info = new List<string>();
        private readonly List<string> _warnings = new List<string>();
        private readonly List<string> _errors = new List<string>();

        public IReadOnlyList<string> Info => _info;
        public IReadOnlyList<string> Warnings => _warnings;
        public IReadOnlyList<string> Errors => _errors;

        public void Log(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            _info.Add(message);
        }

        public void Warn(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            _warnings.Add(message);
        }

        public void Error(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            _errors.Add(message);
        }
    }

    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> _loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            if (loggers == null) throw new ArgumentNullException(nameof(loggers));
            _loggers = loggers.Where(l => l != null).ToList();
        }

        public void Log(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            foreach (var logger in _loggers)
                logger.Log(message);
        }

        public void Warn(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            foreach (var logger in _loggers)
                logger.Warn(message);
        }

        public void Error(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            foreach (var logger in _loggers)
                logger.Error(message);
        }
    }
}