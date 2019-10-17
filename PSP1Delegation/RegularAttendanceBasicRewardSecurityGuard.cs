using PSP1Delegation.Components.Interfaces;
using PSP1Delegation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation
{
    class RegularAttendanceBasicRewardSecurityGuard : SecurityGuard, IAttendancePolicy, IRewardPolicy, IDateCalculator
    {
        private IAttendancePolicy _attendancePolicy;
        private IRewardPolicy _rewardPolicy;
        private IDateCalculator _dateCalculator;

        public RegularAttendanceBasicRewardSecurityGuard(IAttendancePolicy attendancePolicy, IRewardPolicy rewardPolicy, IDateCalculator dateCalculator)
        {
            _attendancePolicy = attendancePolicy;
            _rewardPolicy = rewardPolicy;
            _dateCalculator = dateCalculator;
        }

        public double AdjustIfMainActivity(bool isMain, double chance)
        {
            return _attendancePolicy.AdjustIfMainActivity(isMain, chance);
        }

        public double ChanceOfAttendance(string[] distractions, bool isMain, double chance)
        {
            return _attendancePolicy.ChanceOfAttendance(distractions, isMain, chance);
        }

        public bool CheckUniqueness(string[] distractions)
        {
            return _attendancePolicy.CheckUniqueness(distractions);
        }

        public string TimeSpentInUniversity(DateTime joinedDate)
        {
            return _dateCalculator.TimeSpentInUniversity(joinedDate);
        }

        public double CalculateChanceOfAttendance()
        {
            double chance = 100;
            if (CheckUniqueness(Distractions))
                return ChanceOfAttendance(Distractions, IsUniversityMainActivity, chance);
            else
                return -1;
        }

        public double CalculateRewardChance(double attendancePercent)
        {
            return _rewardPolicy.CalculateRewardChance(AttendancePercent);
        }
    }
}
