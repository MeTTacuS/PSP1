using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    class LazyAttendance
    {
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
            if (distractions.Contains("lazy")) { temp *= 0.9; }

            return AdjustIfMainActivity(isMain, temp);
        }

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
    }
}
