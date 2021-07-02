using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Car : Vehicle
    {
        public Car(string Name, VehicleType Type) : base(Name, Type)
        {
        }
    }
}
