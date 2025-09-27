using System;
using System.Collections.Generic;

namespace App.Topics.Interfaces.T1_1_BasicShapes
{
    // T1.1 BasicShapes - базовый интерфейс и его реализации
    public interface IShape
    {
        string Name { get; }
        double Area();
    }

    public class Rectangle : IShape
    {
        private double _width;
        private double _height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width
        {
            get => _width;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Width must be greater than 0");
                _width = value;
            }
        }

        public double Height
        {
            get => _height;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Height must be greater than 0");
                _height = value;
            }
        }

        public string Name => "Rectangle";

        public double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : IShape
    {
        private double _radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => _radius;
            private set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Radius must be greater than 0");
                _radius = value;
            }
        }

        public string Name => "Circle";

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}

namespace App.Topics.Interfaces.T1_2_CompositeLogger
{
    // T1.2 CompositeLogger - интерфейс и классы (заглушки)
    public interface ILogger
    {
        void Log(string message);
        IEnumerable<string> GetLogs();
    }

    public class MemoryLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLogs()
        {
            throw new NotImplementedException();
        }
    }

    public class CompositeLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}