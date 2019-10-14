using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    class RegularAttendance_HarshScholarshipStudent : Student
    {
        #region
        //private RegularAttendance _regularAttendance;
        //private HarshScholarship _harshScholarship;
        //public RegularAttendance_HarshScholarshipStudent(RegularAttendance attendance, HarshScholarship scholarship)
        //{
        //    _regularAttendance = attendance;
        //    _harshScholarship = scholarship;
        //}

        //protected override double AdjustIfMainActivity(bool isMain, double chance)
        //{
        //    return _regularAttendance.AdjustIfMainActivity(isMain, chance);
        //}
        #endregion

        protected override double AdjustIfMainActivity(bool isMain, double chance)
        {
            if (isMain)
                return chance;
            else
                return chance / 2;
        }

        protected override double CalculateChanceScholarship(double attendancePercent)
        {
            if (attendancePercent > 90)
                return 80;
            if (attendancePercent > 50)
                return 20;
            else
                return 0;
        }

        protected override double ChanceOfAttendance(string[] distractions, bool isMain, double chance)
        {
            var temp = Math.Abs(chance - (100 * (0.1 * distractions.Length)));
            return AdjustIfMainActivity(isMain, temp);
        }

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
    }
}
