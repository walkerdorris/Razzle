using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Razzle.Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razzle.Tests.Sandbox
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void CarEnsureICanCreateAnInstance()
        {
            Car c = new Car();
            Assert.IsNotNull(c);
        }
        [TestMethod]
        public void CarEnsureICanHonk()
        {
            Car c = new Car();
            Assert.AreEqual("Honk", c.Horn());
        }
        [TestMethod]
        public void CarEnsureICanBeep()
        {
            Mock<Car> mock_car = new Mock<Car>();
            mock_car.Setup(car => car.Horn()).Returns("Beep");

            Car c = mock_car.Object;
            Assert.AreEqual("Beep", c.Horn());
        }
        [TestMethod]
        public void CarEnsureHonkWasCalled()
        {
            //Arrange
            Mock<Car> mock_car = new Mock<Car>();
            Car c = mock_car.Object;
            mock_car.Setup(car => car.Horn()).Returns("Beep");
            //Act
            c.MakeNoise(); //This calls the wrong "Horn"; Not the mocked method
            //Assert
            mock_car.Verify(car => car.Horn(), Times.Once); //This never runs
        }
    }
}
