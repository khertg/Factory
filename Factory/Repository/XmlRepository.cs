using Factory.Model;
using System;
using System.IO;
using System.Xml;

namespace Factory.Repository
{
    public class XmlRepository
    {
        private VehicleRepository _vehicleRepo;
        private XmlDocument xmlDoc;
        private string xmlPath;
        public VehicleRepository Vehicle { get { return this._vehicleRepo; } }

        public XmlRepository()
        {
            this.xmlPath = System.Reflection.Assembly.GetExecutingAssembly().Location + "../../../../../vehicle.xml";
            this._vehicleRepo = VehicleRepository.Instance;
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(this.xmlPath);
            this.RemoveAllVehicle();
            this.xmlDoc.Save(this.xmlPath);
            this.PopulateInMemoryVehicle();
        }

        public XmlRepository(string xmlPath)
        {
            this._vehicleRepo = VehicleRepository.Instance;
            this.xmlPath = xmlPath;
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(xmlPath);
            this.RemoveAllVehicle();
            this.xmlDoc.Save(this.xmlPath);
            this.PopulateInMemoryVehicle();

        }

        private void PopulateInMemoryVehicle()
        {
            XmlNodeList vehicleNodes = this.xmlDoc.GetElementsByTagName("vehicle");

            foreach (XmlNode node in vehicleNodes)
            {
                string Name = node.InnerText;
                string AttrType = node.Attributes.GetNamedItem("type").InnerText;
                int Id = Int32.Parse(node.Attributes.GetNamedItem("id").InnerText);
                VehicleType Type = GetVehicleType(AttrType);
                this._vehicleRepo.Create(Name, Type, Id);
            }
        }

        private void RemoveAllVehicle()
        {
            XmlNodeList vehicleNodes = this.xmlDoc.GetElementsByTagName("vehicle");
            if (vehicleNodes.Count > 0)
            {
                vehicleNodes.Item(0).ParentNode.RemoveChild(vehicleNodes.Item(0));
                RemoveAllVehicle();
            }
        }

        public Vehicle CreateVehicle(string Name, VehicleType Type)
        {
            XmlNodeList vehicleNodes = this.xmlDoc.GetElementsByTagName("vehicle");
            int Id = vehicleNodes.Count + 1;
            XmlElement vehicle = this.xmlDoc.CreateElement("vehicle");
            vehicle.SetAttribute("id", Id.ToString());
            vehicle.SetAttribute("type", Type.ToString());
            vehicle.InnerText = Name;

            XmlNodeList vehicles = this.xmlDoc.GetElementsByTagName("vehicles");
            vehicles.Item(0).AppendChild(vehicle);
            this.xmlDoc.Save(this.xmlPath);

            return this._vehicleRepo.Create(Name, Type, Id);
        }

        private VehicleType GetVehicleType(string Type)
        {
            if (Type == VehicleType.Car.ToString())
            {
                return VehicleType.Car;
            }
            else if (Type == VehicleType.Motorcycle.ToString())
            {
                return VehicleType.Car;
            }
            else if (Type == VehicleType.Truck.ToString())
            {
                return VehicleType.Car;
            }
            else
            {
                return VehicleType.Uknown;
            }
        }
    }
}
