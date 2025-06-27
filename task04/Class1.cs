using System;
namespace task04;
public interface ISpaceship
{
    void MoveForward();
    void Rotate(int angle);
    void Fire();
    int Speed { get; }
    int FirePower { get; }
}

public class Cruiser : ISpaceship
{
    public int Speed { get; } = 50;
    public int FirePower { get; } = 100;
    public void MoveForward()
    {
        Console.WriteLine($"Крейсер летит вперёд со скоростью: {Speed}");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"Крейсер поворачивается на {angle} градусов.");
    }
    public void Fire()
    {
        Console.WriteLine($"Крейсер атакует. Огонь! Мощность его выстрела: {FirePower}");
    }

}
public class Fighter : ISpaceship
{
    public int Speed { get; } = 100;
    public int FirePower { get; } = 50;
    public void MoveForward()
    {
        Console.WriteLine($"Истребитель летит вперёд со скорость: {Speed}");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"Истребитель поворачивается на {angle} градусов.");
    }
    public void Fire()
    {
        Console.WriteLine($"Истребитель атакует. Огонь! Мощность его выстрела: {FirePower}");
    }
}
