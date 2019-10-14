using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSPTreciaDalis.Interfaces;

namespace PSPTreciaDalis.Entities
    {
    public class Enclosure : IImprovementPolitics, IMigrationPolitics, IMaintenancePolitics
    {
        private IImprovementPolitics _improvementPolitics;
        private IMaintenancePolitics _maintenancePolitics;
        private IMigrationPolitics _migrationPolitics;
        public int _quality { get; set; }
        public double _qualityCounter { get; set; }
        public double _sustain { get; set; }

        public Enclosure (IImprovementPolitics improvementPolitics = null, IMaintenancePolitics maintenancePolitics = null, IMigrationPolitics migrationPolitics = null)
            {
            _qualityCounter = 0;
            _improvementPolitics = improvementPolitics;
            _maintenancePolitics = maintenancePolitics;
            _migrationPolitics = migrationPolitics;
            }

        public double Enclose(DateTime startTime, DateTime endTime)
        {
            double enclosementDuration = (endTime - startTime).TotalHours;
            _qualityCounter -= Math.Round(enclosementDuration, 2);

            CheckQuality();

            return Math.Round(enclosementDuration * 2);
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

        public double? ImprovementCost (double qualityCounter)
            {
            return _improvementPolitics?.ImprovementCost(qualityCounter);
            }
        public double? MaintenanceCost (int quality, double sustain)
            {
            return _maintenancePolitics?.MaintenanceCost(quality, sustain);
            }
        public double? MigrationCost (int quality)
            {
            return _migrationPolitics?.MigrationCost(quality);
            }
        }
    }
