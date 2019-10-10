using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1.ScholarshipConditions
{
    interface IScholarshipConditionCalculator
    {
        double CalculateChance(double attendancePercent);
    }
}
