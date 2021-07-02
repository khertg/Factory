using Factory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Repository
{
    public class XmlRepository : IRepository
    {
        public List<Vehicle> VehicleList;

        public XmlRepository()
        {
            this.VehicleList = new List<Vehicle>();
        }
        public Vehicle Create(string Name, VehicleType Type)
        {
            switch (Type)
            {
                case VehicleType.Car:
                    {
                        Vehicle newVehicle = new Car(Name, Type);
                        this.VehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                case VehicleType.Truck:
                    {
                        Vehicle newVehicle = new Truck(Name, Type);
                        this.VehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                case VehicleType.Motorcycle:
                    {
                        Vehicle newVehicle = new Motorcycle(Name, Type);
                        this.VehicleList.Add(newVehicle);
                        return newVehicle;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public List<Vehicle> Get()
        {
            throw new NotImplementedException();
            //return this.VehicleList;
        }

        public List<Vehicle> Get(string Name)
        {
            throw new NotImplementedException();
            //return this.VehicleList.FindAll(v => v.Name == Name);
        }

        public List<Vehicle> Get(VehicleType Type)
        {
            throw new NotImplementedException();
            //return this.VehicleList.FindAll(v => v.Type == Type);
        }
    }
}
