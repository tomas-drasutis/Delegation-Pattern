using System;
using System.Collections.Generic;
using System.Text;
using PSPTreciaDalis.Interfaces;

namespace PSPTreciaDalis.InterfaceImplementations
{
    public class ImprovementPolitics : IImprovementPolitics
    {
        public double? ImprovementCost(double qualityCounter)
        {
            if (qualityCounter > 0)
                return Math.Round(qualityCounter / 2, 2);
            else
                return Math.Abs(qualityCounter);
        }
    }
}
