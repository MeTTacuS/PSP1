using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    class RegularAttendance_BasicScholarshipStudent : Student
    {
        protected override bool CheckUniqueness(string[] distractions)
        {
            HashSet<string> s = new HashSet<string>(distractions);
            if (s.Count == distractions.Length)
                return true;
            else
            {
                Console.WriteLine("Some distractions are identical, calculations cannot continue");
                return false;
            }
        }
        protected override double AdjustIfMainActivity(bool isMain, double chance)
        {
            if (isMain)
                return chance;
            else
                return chance / 2;
        }

        protected override double ChanceOfAttendance(string[] distractions, bool isMain, double chance)
        {
            var temp = Math.Abs(chance - (100 * (0.1 * distractions.Length)));
            return AdjustIfMainActivity(isMain, temp);
        }

        protected override double CalculateChanceScholarship(double attendancePercent)
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
