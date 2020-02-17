using System;

internal class Solution
{
    private static void Main(string[] args)
    {
        ContinentFactory africa = new AnimalFactory();
        var world = new AnimalWorld(africa);
        world.RunFoodChain();

        ContinentFactory america = new AnimalFactory();
        var worldAmerica = new AnimalWorld(america);
        worldAmerica.RunFoodChain();

        Console.ReadKey();
    }

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }

    private class AnimalFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }

    abstract class Herbivore { }

    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    private class WildBeast : Herbivore { }

    private class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(GetType().Name + "eats" + h.GetType().Name);
        }
    }

    private class Bison : Herbivore { }

    private class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(GetType().Name + "eats" + h.GetType().Name);
        }
    }

    private class AnimalWorld
    {
        private readonly Carnivore _carnivore;
        private readonly Herbivore _herbivore;

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }
}