using Microsoft.VisualStudio.TestTools.UnitTesting;
using Factory;
using System.Linq;
using Factory.Repository;

namespace Unit_Test
{

    [TestClass]
    public class FactoryMethodTest {

        private IVehicleFactory factory;
        [TestInitialize]
        public void Init()
        {
            factory = new VehicleFactory(new XmlRepository());
        }
        [TestMethod]
        public void ShouldCreateANewCar()
        {
            var car1 = factory.Create("Car 1", VehicleType.Car);
            Assert.IsTrue(car1 is Car);
            Assert.AreEqual("Car 1", car1.Name);
            Assert.AreEqual(VehicleType.Car, car1.Type);
            Assert.IsTrue(car1.Id > 0);
        }
        [TestMethod]
        public void ShouldCreateNewTruck()
        {
            var truck1 = factory.Create("Truck 1", VehicleType.Truck);
            Assert.IsTrue(truck1 is Truck);
            Assert.AreEqual("Truck 1", truck1.Name);
            Assert.AreEqual(VehicleType.Truck, truck1.Type);
            Assert.IsTrue(truck1.Id > 0);
        }
        [TestMethod]
        public void ShouldCreateNewMotorcycle()
        {
            var mc1 = factory.Create("Mc 1", VehicleType.Motorcycle);
            Assert.IsTrue(mc1 is Motorcycle);
            Assert.AreEqual("Mc 1", mc1.Name);
            Assert.AreEqual(VehicleType.Motorcycle, mc1.Type);
            Assert.IsTrue(mc1.Id > 0);
        }
        [TestMethod]
        public void ShouldGiveMeAllVehicles()
        {
            var vehicles = factory.Get();
            Assert.AreEqual(3, vehicles.Count());
        }
        [TestMethod]
        public void ShouldGiveMeAllCars()
        {
            var cars = factory.Get(VehicleType.Car);
            Assert.IsTrue(cars.All(car => car is Car));
            Assert.AreEqual(1, cars.Count());
        }
        [TestMethod]
        public void ShouldGiveMeCar1()
        {
            var cars = factory.Get("Car 1");
            Assert.IsTrue(cars.All(car => car.Name == "Car 1"));
            Assert.IsTrue(cars.All(car => car.Id > 0));
            Assert.AreEqual(1, cars.Count());
        }
    }
}
