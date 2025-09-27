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

    public double Area()
    {
        return Width * Height;
    }
    public Rectangle(double width, double height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), "Ширина должна быть положительной");
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), "Высота должна быть положительной");
        }

        Width = width;
        Height = height;
    }
}
public class Circle : IShape
{
    public double Radius { get; }
    public string Name => "Circle";

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius));
        }

        Radius = radius;
    }
}