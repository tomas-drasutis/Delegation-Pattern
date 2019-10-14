using NUnit.Framework;
using PSPTreciaDalis.Entities;
using PSPTreciaDalis.InterfaceImplementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MixinTests
{
    public class MixinTests
    {
        [Test]
        public void Anmal_NonExistantMixins_ReturnsNull()
        {
            Animal animal = new Animal();

            Assert.AreEqual(null, animal.ImprovementCost(animal._qualityCounter));
            Assert.AreEqual(null, animal.MaintenanceCost(animal._quality, animal._foodCost));
            Assert.AreEqual(null, animal.MigrationCost(animal._quality));
        }

        [Test]
        public void EmployeeNonExistantMixins_ReturnsNull()
        {
            Employee employee = new Employee();

            Assert.AreEqual(null, employee.ImprovementCost(employee._qualityCounter));
            Assert.AreEqual(null, employee.MaintenanceCost(employee._quality, employee._hourlyWage));
            Assert.AreEqual(null, employee.MigrationCost(employee._quality));
        }

        [Test]
        public void EnclosureNonExistantMixins_ReturnsNull()
        {
            Enclosure enclosure = new Enclosure();

            Assert.AreEqual(null, enclosure.ImprovementCost(enclosure._qualityCounter));
            Assert.AreEqual(null, enclosure.MaintenanceCost(enclosure._quality, enclosure._sustain));
            Assert.AreEqual(null, enclosure.MigrationCost(enclosure._quality));
        }

        [Test]
        public void AnimalImprovementCost_Succeeds()
        {
            Animal animal = new Animal(new ImprovementPolitics()) { _qualityCounter = -45};

            Assert.AreEqual(45, animal.ImprovementCost(animal._qualityCounter));
            Assert.AreEqual(null, animal.MaintenanceCost(animal._quality, animal._foodCost));
            Assert.AreEqual(null, animal.MigrationCost(animal._quality));
        }

        [Test]
        public void AnimalImprovementMaintenanceCost_Succeeds()
        {
            Animal animal = new Animal(new ImprovementPolitics(), new MaintenancePolitics()) { _qualityCounter = -45, _foodCost = 10.50 };

            Assert.AreEqual(45, animal.ImprovementCost(animal._qualityCounter));
            Assert.AreEqual(10.5, animal.MaintenanceCost(animal._quality, animal._foodCost));
            Assert.AreEqual(null, animal.MigrationCost(animal._quality));
        }

        [Test]
        public void AnimalAllCosts_Succeeds()
        {
            Animal animal = new Animal(new ImprovementPolitics(), new MaintenancePolitics(), new MigrationPolitics()) { _quality = 5,_qualityCounter = -45, _foodCost = 10.50 };

            Assert.AreEqual(45, animal.ImprovementCost(animal._qualityCounter));
            Assert.AreEqual(52.5, animal.MaintenanceCost(animal._quality, animal._foodCost));
            Assert.AreEqual(100, animal.MigrationCost(animal._quality));
        }

        [Test]
        public void EnclosureMaintenanceCost_Succeeds()
        {
            Enclosure enclosure = new Enclosure(null, new MaintenancePolitics()) { _qualityCounter = -45, _sustain = 10.50 };

            Assert.AreEqual(null, enclosure.ImprovementCost(enclosure._qualityCounter));
            Assert.AreEqual(10.5, enclosure.MaintenanceCost(enclosure._quality, enclosure._sustain));
            Assert.AreEqual(null, enclosure.MigrationCost(enclosure._quality));
        }

        [Test]
        public void EmployeeMigrationCosts_Succeeds()
        {
            Employee employee = new Employee(null, null, new MigrationPolitics()) { _quality = 5, _qualityCounter = -45, _hourlyWage = 10.50 };

            Assert.AreEqual(null, employee.ImprovementCost(employee._qualityCounter));
            Assert.AreEqual(null, employee.MaintenanceCost(employee._quality, employee._hourlyWage));
            Assert.AreEqual(100, employee.MigrationCost(employee._quality));
        }

    }
}
