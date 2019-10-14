using PSPTreciaDalis.Interfaces;
using System;
using System.Linq;

namespace PSPTreciaDalis.Entities
{
    public class Animal : IImprovementPolitics, IMigrationPolitics, IMaintenancePolitics
    {
        private IImprovementPolitics _improvementPolitics;
        private IMaintenancePolitics _maintenancePolitics;
        private IMigrationPolitics _migrationPolitics;
        public int _quality { get; set; }
        public double _qualityCounter { get; set; }
        public double _foodCost { get; set; }

        public Animal(IImprovementPolitics improvementPolitics = null, IMaintenancePolitics maintenancePolitics = null, IMigrationPolitics migrationPolitics = null)
        {
            _qualityCounter = 0;
            _improvementPolitics = improvementPolitics;
            _maintenancePolitics = maintenancePolitics;
            _migrationPolitics = migrationPolitics;
        }

        public double Entertain(DateTime startTime, DateTime endTime)
        {
            double entertainmentDuration = (endTime - startTime).TotalHours;
            _qualityCounter -= Math.Round(entertainmentDuration, 2);

            CheckQuality();

            return Math.Round(entertainmentDuration * 2);
        }

        public double RandomEvent()
        {
            Random rnd = new Random();
            int eventDamage = rnd.Next(-50, 50);

            _qualityCounter -= eventDamage;

            CheckQuality();

            return eventDamage * 2;
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

        public double? ImprovementCost(double qualityCounter)
        {
            return _improvementPolitics?.ImprovementCost(qualityCounter);
        }
        public double? MaintenanceCost(int quality, double foodCost)
        {
            return _maintenancePolitics?.MaintenanceCost(quality, foodCost);
        }
        public double? MigrationCost(int quality)
        {
            return _migrationPolitics?.MigrationCost(quality);
        }
    }
}
