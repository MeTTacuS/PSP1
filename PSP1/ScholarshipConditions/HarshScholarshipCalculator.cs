using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1.ScholarshipConditions
{
    class HarshScholarshipCalculator : IScholarshipConditionCalculator
    {
        public double CalculateChance(double attendance)
        {
            if (attendance > 90)
                return 80;
            if (attendance > 50)
                return 20;
            else
                return 0;
        }
    }
}
