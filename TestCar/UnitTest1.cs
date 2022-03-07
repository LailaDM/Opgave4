using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave4.Managers;
using Opgave4.Models;

namespace TestCar
{
    [TestClass]
    public class UnitTest1
    {
        private CarsManager _manager;

        [TestInitialize]
        public void Init()
        {
            _manager = new CarsManager();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsInstanceOfType( _manager.GetAll("Audi", 1000000,"AB12345"), typeof(List<Car>));
            Assert.IsInstanceOfType(_manager.GetAll("Skoda", 100000, "BC12345"), typeof(List<Car>));
            Assert.IsInstanceOfType(_manager.GetAll("Tesla", 900000, "CD12345"), typeof(List<Car>));
            Assert.IsInstanceOfType(_manager.GetAll("Peugot", 50000, "DE12345"), typeof(List<Car>));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsInstanceOfType(_manager.GetById(2), typeof(Car));
        }


        [TestMethod]
        public void TestMethod3()
        {
            Car car1 = new Car(5,"Kia Rio", 2000, "DF98765");
                Assert.AreEqual(_manager.Add(car1), car1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsNotNull(_manager.Delete(3));
        }

    }
}
