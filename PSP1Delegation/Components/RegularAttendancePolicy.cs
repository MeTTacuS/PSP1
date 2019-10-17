using PSP1Delegation.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation.Components
{
    class RegularAttendancePolicy : IAttendancePolicy
    {
        public bool CheckUniqueness(string[] distractions)
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

        public double AdjustIfMainActivity(bool isMain, double chance)
        {
            if (isMain)
                return chance;
            else
                return chance / 2;
        }
        public double ChanceOfAttendance(string[] distractions, bool isMain, double chance)
        {
            var temp = Math.Abs(chance - (100 * (0.1 * distractions.Length)));
            return AdjustIfMainActivity(isMain, temp);
        }

        public double CalculateChanceOfAttendance(string[] distractions, bool isMain)
        {
            double chance = 100;
            if (CheckUniqueness(distractions))
                return ChanceOfAttendance(distractions, isMain, chance);
            else
                return -1;
        }
    }
}
