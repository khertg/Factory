using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public interface IVehicleFactory
    {
        public Vehicle Create(string Name, VehicleType Type);

        public List<Vehicle> Get();

        public List<Vehicle> Get(string Name);

        public List<Vehicle> Get(VehicleType Type);

    }
}
