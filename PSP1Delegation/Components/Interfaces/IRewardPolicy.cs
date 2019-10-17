using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation.Components.Interfaces
{
    interface IRewardPolicy
    {
        double CalculateRewardChance(double attendancePercent);
    }
}
