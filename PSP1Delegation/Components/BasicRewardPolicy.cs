using PSP1Delegation.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation.Components
{
    class BasicRewardPolicy : IRewardPolicy
    {
        public double CalculateRewardChance(double attendance)
        {
            if (attendance > 90)
                return 98;
            if (attendance > 50)
                return 40;
            else
                return 20;
        }
    }
}
