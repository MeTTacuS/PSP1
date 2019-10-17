using PSP1Delegation.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation.Components
{
    class YearsInUniversityCalculator : IDateCalculator
    {
        public string TimeSpentInUniversity(DateTime joinedDate)
        {
            var year = DateTime.Now.Year - joinedDate.Year;
            if (year == 0) { return "This is his/hers first year in university"; }
            else if (year == 1) { return "This person has spent 1 year in university"; }
            else { return "This person has spent " + year + " years in university"; }
        }
    }
}
