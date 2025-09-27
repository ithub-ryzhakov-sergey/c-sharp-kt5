// Topic 1: Interfaces
// Task T1.1 BasicShapes (обязательная)
// В этом файле описан интерфейс IShape и заготовки классов фигур.
// Ваша задача — реализовать проверки, свойства и методы согласно README.

namespace App.Topics.Interfaces.T1_1_BasicShapes;

public interface IShape
{
    string Name { get; }
    double Area();
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }
    public string Name => "Rectangle";

    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;

        if (width <= 0)
            throw new ArgumentOutOfRangeException(nameof(width));
        if (height <= 0)
            throw new ArgumentOutOfRangeException(nameof(height));
    }

    public double Area()
    {
        return Width * Height;
    }
}  

public class Circle : IShape
{
    public double Radius { get; }
    public string Name => "Circle";

    public Circle(double radius)
    {
        this.Radius = radius;

        if (radius <= 0)
            throw new ArgumentOutOfRangeException(nameof(radius));
    }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
}


