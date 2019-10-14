using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    class HarshScholarship
    {
        public double CalculateChanceScholarship(double attendancePercent)
        {
            if (attendancePercent > 90)
                return 80;
            if (attendancePercent > 50)
                return 20;
            else
                return 0;
        }
    }
}
