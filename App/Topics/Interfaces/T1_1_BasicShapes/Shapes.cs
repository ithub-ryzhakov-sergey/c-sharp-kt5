using System;

namespace App.Topics.Interfaces.T1_1_BasicShapes
{
    public interface IShape
    {
        string Name { get; }
        double Area();
    }

    public class Rectangle : IShape
    {
        public string Name => "Rectangle";

        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "Width must be greater than 0.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Height must be greater than 0.");

            Width = width;
            Height = height;
        }

        public double Area()
        {
            return Width * Height;
        }
    }

    public class Circle : IShape
    {
        public string Name => "Circle";

        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be greater than 0.");

            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}