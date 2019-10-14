using System;
using System.Collections.Generic;
using System.Text;
using PSPTreciaDalis.Entities;
using PSPTreciaDalis.Interfaces;

namespace PSPTreciaDalis.InterfaceImplementations
{
    public class MaintenancePolitics : IMaintenancePolitics
    {
        public double? MaintenanceCost(int quality, double maintenanceParameter)
        {
            if (quality > 4)
                return Math.Round(maintenanceParameter * (int)quality, 2);
            else
                return maintenanceParameter;
        }

    }
}
