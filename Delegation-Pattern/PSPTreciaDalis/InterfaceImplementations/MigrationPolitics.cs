using System;
using System.Collections.Generic;
using System.Text;
using PSPTreciaDalis.Entities;
using PSPTreciaDalis.Interfaces;

namespace PSPTreciaDalis.InterfaceImplementations
{
    public class MigrationPolitics : IMigrationPolitics
    {
        public double? MigrationCost(int quality)
        {
            double cost = 0;
            switch (quality)
            {
                case 1:
                case 2:
                    cost = 15;
                break;
                case 3:
                case 4:
                    cost = 42;
                    break;
                default:
                    cost = 100;
                    break;
            }
            return cost;
        }
    }
}
