using CarsAPI.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Tests
{
    public class CarFixture : IDisposable
    {
        public CarDealer CardDealer { get; set; }
        public Car Car { get; set; }

        public CarFixture()
        {
            CardDealer = new CarDealer();
            Car = new Car();
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
