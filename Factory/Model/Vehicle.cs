using System;
using System.Collections.Generic;
using System.Text;

namespace Factory.Model
{
    public class Vehicle
    {
        public Vehicle(string Name, VehicleType Type)
        {
            this.Name = Name;
            this.Type = Type;
            this.Id = 1;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleType Type { get; set; }
    }
}
