using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<string> Info { get; } = new List<string>();
        public List<string> Warnings { get; } = new List<string>();
        public List<string> Errors { get; } = new List<string>();

        public void Log(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            Info.Add(message);
        }

        public void Warn(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            Warnings.Add(message);
        }

        public void Error(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            Errors.Add(message);
        }
    }

    public class CompositeLogger : ILogger
    {
        private readonly ILogger[] loggers;

        public CompositeLogger(IEnumerable<ILogger> loggers)
        {
            if (loggers == null)
                throw new ArgumentNullException(nameof(loggers));

            // Фильтруем null-логгеры внутри коллекции
            this.loggers = loggers.Where(l => l != null).ToArray();
        }

        public void Log(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            foreach (var logger in loggers)
            {
                logger.Log(message);
            }
        }

        public void Warn(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            foreach (var logger in loggers)
            {
                logger.Warn(message);
            }
        }

        public void Error(string message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            foreach (var logger in loggers)
            {
                logger.Error(message);
            }
        }
    }
}