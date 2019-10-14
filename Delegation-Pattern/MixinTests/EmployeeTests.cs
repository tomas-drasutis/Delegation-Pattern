using NUnit.Framework;
using PSPTreciaDalis.Entities;
using System;

namespace MixinTests
{
    public class EmployeeTests
    {

        [Test]
        public void GroomAnimal_Succeeds()
        {
            Employee employee = new Employee() { _hourlyWage = 1 };
            Animal animal = new Animal() { _quality = 3, _qualityCounter = -50 };

            Assert.AreEqual(-100, employee.GroomAnimal(animal, DateTime.Now.AddHours(-2), DateTime.Now));
            Assert.AreEqual(0, animal._qualityCounter);
        }

        [Test]
        public void CleanEnclosure_Succeeds()
        {
            Employee employee = new Employee() { _hourlyWage = 1 };
            Enclosure enclosure = new Enclosure() { _quality = 3, _qualityCounter = -50 };

            Assert.AreEqual(-100, employee.CleanEnclosure(enclosure, DateTime.Now.AddHours(-2), DateTime.Now));
            Assert.AreEqual(0, enclosure._qualityCounter);
        }
    }
}