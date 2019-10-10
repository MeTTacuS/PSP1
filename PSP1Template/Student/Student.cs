using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template
{
    abstract class Student
    {
        private bool _isUniversityMainActivity;
        private string[] _distratctions;
        private double _attendancePercent;

        public void SetDistractions(string[] distractions)
        {
            _distratctions = distractions;
        }

        public void SetMainActivity(bool val)
        {
            _isUniversityMainActivity = val;
        }
        public void SetAttendancePercent(double val)
        {
            _attendancePercent = val;
        }

        protected abstract bool CheckUniqueness(string[] distractions);
        protected abstract double AdjustIfMainActivity(bool isMain, double chance);
        protected abstract double ChanceOfAttendance(string[] distractions, bool isMain, double chance);
        protected abstract double CalculateChanceScholarship(double attendancePercent);

        public double CalculateChanceOfAttendance()
        {
            double chance = 100;
            if (CheckUniqueness(_distratctions))
                return ChanceOfAttendance(_distratctions, _isUniversityMainActivity, chance);
            else
                return -1;
        }

        public double CalculateChanceOfScholarship()
        {
            return CalculateChanceScholarship(_attendancePercent);
        }
    }
}
