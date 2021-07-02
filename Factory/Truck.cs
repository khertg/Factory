using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Truck : Vehicle
    {
        public Truck(string Name, VehicleType Type) : base(Name, Type)
        {
        }
    }
}
