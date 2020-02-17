using System;
using Facade.SubSystem;

namespace Facade.Facade
{
    // Tuka moze i so interfejs da se pristapi za pocist kod
    public class CarFacade
    {
        private readonly CarModel _model;
        private readonly CarBody _body;
        private readonly CarEngine _engine;
        private readonly CarAccessories _accessories;
        
        public CarFacade()
        {
            _model = new CarModel();
            _body = new CarBody();
            _engine = new CarEngine();
            _accessories = new CarAccessories();
        }

        public void CreateCompleteCar()
        {
            Console.WriteLine("Create complete Car");
            Console.WriteLine("===================================");

            _model.SetModel();
            _body.SetBody();
            _engine.SetEngine();
            _accessories.SetAccessories();

            Console.WriteLine("===================================");
            Console.WriteLine("Car Completed");

        }
    }
}