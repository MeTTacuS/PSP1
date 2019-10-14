using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    class BasicScholarship
    {
        public double CalculateChanceScholarship(double attendancePercent)
        {
            if (attendancePercent > 90)
                return 98;
            if (attendancePercent > 50)
                return 40;
            else
                return 20;
        }
    }
}
