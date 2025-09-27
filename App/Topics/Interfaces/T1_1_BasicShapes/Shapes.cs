// Topic 1: Interfaces
// Task T1.1 BasicShapes (обязательная)
// В этом файле описан интерфейс IShape и заготовки классов фигур.
// Ваша задача — реализовать проверки, свойства и методы согласно README.

namespace App.Topics.Interfaces.T1_1_BasicShapes;

interface IShape
{
    string Name { get; }
    double Area();
}

public class Rectangle: IShape {
    public double Width { get; }
    public double Height { get; }
    public string Name { get; } 
    public double Area()
    {
        return this.Width * this.Height;
    }
    public Rectangle(double width, double height)
    {
        if (!(width > 0) || !(height > 0))
        {
            throw new ArgumentOutOfRangeException();
        }
        this.Name = "Rectangle";
        this.Width = width;
        this.Height = height;
    }
 }
public class Circle: IShape {
    public double Radius { get; }
    public string Name { get; }
    public double Area()
    {
        return Math.PI * Radius * Radius;
    }
    public Circle(double radius)
    {
        if (!(radius > 0))
        {
            throw new ArgumentOutOfRangeException();
        }
        this.Name = "Circle";
        this.Radius = radius;
    }
}