using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Repository
{
    public interface IRepository
    {
        public List<Vehicle> Get();
        public List<Vehicle> Get(string Name);
        public List<Vehicle> Get(VehicleType Type);
        public Vehicle Create(string Name, VehicleType Type);
    }
}
