using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSPTreciaDalis.Interfaces;

namespace PSPTreciaDalis.Entities
    {
    public class Employee : IImprovementPolitics, IMigrationPolitics, IMaintenancePolitics
    {
        private IImprovementPolitics _improvementPolitics;
        private IMaintenancePolitics _maintenancePolitics;
        private IMigrationPolitics _migrationPolitics;
        public double _hourlyWage { get; set; }
        public int _quality { get; set; }
        public double _qualityCounter { get; set; }


        public Employee (IImprovementPolitics improvementPolitics = null, IMaintenancePolitics maintenancePolitics = null, IMigrationPolitics migrationPolitics = null)
            {
            _qualityCounter = 0;
            _improvementPolitics = improvementPolitics;
            _maintenancePolitics = maintenancePolitics;
            _migrationPolitics = migrationPolitics;
            }

        public double GroomAnimal(Animal animal, DateTime startTime, DateTime endTime)
        {
            double groomingDuration = (endTime - startTime).TotalHours;
            double cost;

            cost = animal._qualityCounter * groomingDuration * _hourlyWage;
            _qualityCounter += animal._qualityCounter;

            animal._qualityCounter = 0;            
            CheckQuality();

            return Math.Round(cost, 2);
        }

        public double CleanEnclosure(Enclosure enclosure, DateTime startTime, DateTime endTime)
        {
            double cleaningDuration = (endTime - startTime).TotalHours;
            double cost;

            cost = enclosure._qualityCounter * cleaningDuration * _hourlyWage;
            _qualityCounter += enclosure._qualityCounter;

            enclosure._qualityCounter = 0;            
            CheckQuality();

            return Math.Round(cost, 2);
        }

        private void CheckQuality()
        {
            if (_qualityCounter <= -100)
            {
                _quality -= 1;
                _qualityCounter = 0;
            }
            else if (_qualityCounter >= 100)
            {
                _quality += 1;
                _qualityCounter = 0;
            }
        }

        public double? ImprovementCost (double qualityCounter)
            {
            return _improvementPolitics?.ImprovementCost(qualityCounter);
            }
        public double? MaintenanceCost (int quality, double hourlyWage)
            {
            return _maintenancePolitics?.MaintenanceCost(quality, hourlyWage);
            }
        public double? MigrationCost (int quality)
            {
            return _migrationPolitics?.MigrationCost(quality);
            }
        }
    }
