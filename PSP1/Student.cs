using PSP1;
using PSP1.ScholarshipConditions;

namespace PSP1Strategy
{
    class Student
    {
        private bool _isUniversityMainActivity;
        private string[] _distratctions;
        private IAttendancePolicy _attendancePolicy;
        private IScholarshipConditionCalculator _scholarshipCalculator;
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

        public double CalculateChanceOfAttendance(IAttendancePolicy policy)
        {
            double chance = 100;
            _attendancePolicy = policy;
            if (_attendancePolicy.CheckUniqueness(_distratctions))
                return _attendancePolicy.ChanceOfAttendance(_distratctions, _isUniversityMainActivity, chance);
            else
                return -1;
        }

        public double CalculateChanceOfScholarship(IScholarshipConditionCalculator condition)
        {
            _scholarshipCalculator = condition;
            return _scholarshipCalculator.CalculateChance(_attendancePercent);
        }
    }
}
