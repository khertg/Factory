using Factory.Model;
using Factory.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class VehicleFactory: IVehicleFactory
    {
        private readonly IRepository _respository;

        public VehicleFactory(XmlRepository repository)
        {
            this._respository = repository;
        }

        public Vehicle Create(string Name, VehicleType Type)
        {
            return this._respository.Create(Name, Type);
        }

        public List<Vehicle> Get()
        {
            return this.Get();
        }

        public List<Vehicle> Get(string Name)
        {
            return this.Get(Name);
        }

        public List<Vehicle> Get(VehicleType Type)
        {
            return this.Get(Type);
        }
    }
}
