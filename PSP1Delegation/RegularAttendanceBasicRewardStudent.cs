using PSP1Delegation.Components.Interfaces;
using PSP1Delegation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Delegation
{
    class RegularAttendanceBasicRewardStudent : Student, IAttendancePolicy, IRewardPolicy, IDateCalculator
    {
        private IAttendancePolicy _attendancePolicy;
        private IRewardPolicy _scholarshipPolicy;
        private IDateCalculator _dateCalculator;

        public RegularAttendanceBasicRewardStudent(IAttendancePolicy attendancePolicy, IRewardPolicy scholarshipPolicy, IDateCalculator dateCalculator)
        {
            _attendancePolicy = attendancePolicy;
            _scholarshipPolicy = scholarshipPolicy;
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

        public double CalculateRewardChance(double attendancePercent)
        {
            return _scholarshipPolicy.CalculateRewardChance(AttendancePercent);
        }

        public double CalculateChanceOfAttendance(string[] distractions, bool isMain)
        {
            return _attendancePolicy.CalculateChanceOfAttendance(distractions, isMain);
        }
    }
}
