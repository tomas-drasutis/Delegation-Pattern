using PSPTreciaDalis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSPTreciaDalis.Interfaces
    {
    public interface IMaintenancePolitics
        {
        double? MaintenanceCost (int quality, double maintenanceParameter);
        }
    }
