using PSP1Delegation.Components;
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
        private IAttendancePolicy _attendancePolicy = new RegularAttendancePolicy();
        private IRewardPolicy _rewardPolicy = new BasicRewardPolicy();
        private IDateCalculator _dateCalculator = new YearsInUniversityCalculator();

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

        public double CalculateRewardChance(double attendancePercent)
        {
            return _rewardPolicy.CalculateRewardChance(AttendancePercent);
        }

        public double CalculateChanceOfAttendance(string[] distractions, bool isMain)
        {
            return _attendancePolicy.CalculateChanceOfAttendance(distractions, isMain);
        }
    }
}
