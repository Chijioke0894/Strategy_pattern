// See https://aka.ms/new-console-template for more information

// Interface created for the flight strategy
public interface IMovementBehavior
{
    void Fly();
}

// movement behaviour for birds that can fly
public class FlapWings : IMovementBehavior
{
    public void Fly()
    {
        Console.WriteLine("movement behaviour: *Flies by flapping wings*");
    }
}

// movement implementation for penguins
public class Sliding : IMovementBehavior
{
    public void Fly()
    {
        Console.WriteLine("movement behaviour: *Slides on its belly*");
    }
}

// movement implementation for flightless birds
public class NoFly : IMovementBehavior
{
    public void Fly()
    {
        Console.WriteLine("movement behaviour: *hides head in the sand as it cannot fly*");
    }
}

// movement implementation for rubber ducks
public class Floating : IMovementBehavior
{
    public void Fly()
    {
        Console.WriteLine("movement behaviour: *Floats in water*");
    }
}

// Parent class for all birds
public class Bird
{
    private readonly IMovementBehavior movementBehavior;

    public Bird(IMovementBehavior movementBehavior)
    {
        this.movementBehavior = movementBehavior;
    }

    public void PerformMovement()
    {
        movementBehavior.Fly();
    }
}

// Derived classes for specific birds
public class MallardDuck : Bird
{
    public MallardDuck() : base(new FlapWings())
    {
    }
}

public class EmperorPenguin : Bird
{
    public EmperorPenguin() : base(new Sliding())
    {
    }
}

public class BaldEagle : Bird
{
    public BaldEagle() : base(new FlapWings())
    {
    }
}

public class Ostrich : Bird
{
    public Ostrich() : base(new NoFly())
    {
    }
}

public class YellowRubberDuck : Bird
{
    public YellowRubberDuck() : base(new Floating())
    {
    }
}

class Program
{
    static void Main()
    {
        List<Bird> birds = new List<Bird>
        {
            new MallardDuck(),
            new EmperorPenguin(),
            new BaldEagle(),
            new Ostrich(),
            new YellowRubberDuck()
        };

        foreach (var bird in birds)
        {
            Console.WriteLine($"Type of bird: {bird.GetType().Name}");
            bird.PerformMovement();
            Console.WriteLine();
        }
    }
}
