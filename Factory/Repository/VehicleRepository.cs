using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Repository
{
    public sealed class VehicleRepository : IRepository
    {
        private static List<Vehicle> vehicleList = new List<Vehicle>();

        private static readonly Lazy<VehicleRepository> lazy = new Lazy<VehicleRepository>(() => new VehicleRepository());

        public static VehicleRepository Instance { get { return lazy.Value; } }

        private VehicleRepository()
        {
        }

        public List<Vehicle> Get()
        {
            return vehicleList;
        }

        public List<Vehicle> Get(string Name)
        {
            return vehicleList.FindAll(v => v.Name == Name);
        }

        public List<Vehicle> Get(VehicleType Type)
        {
            return vehicleList.FindAll(v => v.Type == Type);
        }

        public Vehicle Create(string Name, VehicleType Type, int Id = 0)
        {
            switch (Type)
            {
                case VehicleType.Car:
                    {
                        Vehicle newVehicle = new Car(Name, Type);
                        vehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                case VehicleType.Truck:
                    {
                        Vehicle newVehicle = new Truck(Name, Type);
                        vehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                case VehicleType.Motorcycle:
                    {
                        Vehicle newVehicle = new Motorcycle(Name, Type);
                        vehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }
    }
}
