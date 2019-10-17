using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation.Components.Interfaces
{
    interface IAttendancePolicy
    {
        bool CheckUniqueness(string[] distractions);
        double AdjustIfMainActivity(bool isMain, double chance);
        double ChanceOfAttendance(string[] distractions, bool isMain, double chance);
        double CalculateChanceOfAttendance(string[] distractions, bool isMain);
    }
}
