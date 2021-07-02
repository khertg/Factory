using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string Name, VehicleType Type) : base(Name, Type)
        {
        }
    }
}
