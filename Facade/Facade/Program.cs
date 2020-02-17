using System;
using Facade.Facade;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CarFacade car = new CarFacade();
            car.CreateCompleteCar();
            Console.ReadLine();
        }
    }
}
