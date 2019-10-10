using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1
{
    class Lecturer
    {
        private bool _isUniversityTheOnlyJob;
        private string[] _distratctions;
        private IAttendancePolicy _attendancePolicy;
        private int _amountOfLectures = 1;

        public void SetDistractions(string[] distractions)
        {
            _distratctions = distractions;
        }
        public void SetLectures(int lectures)
        {
            _amountOfLectures = lectures;
        }

        public void IsUniMainJob(bool val)
        {
            _isUniversityTheOnlyJob = val;
        }

        public double CalculateChanceOfAttendance(IAttendancePolicy policy)
        {
            double chance = 100;
            _attendancePolicy = policy;

            if (_amountOfLectures >= 3)
            {
                chance *= 0.8;
                if (_attendancePolicy.CheckUniqueness(_distratctions))
                    return _attendancePolicy.ChanceOfAttendance(_distratctions, _isUniversityTheOnlyJob, chance);
                else
                    return -1;
            }
            else
            {
                _attendancePolicy = policy;
                if (_attendancePolicy.CheckUniqueness(_distratctions))
                    return _attendancePolicy.ChanceOfAttendance(_distratctions, _isUniversityTheOnlyJob, chance);
                else
                    return -1;
            }
        }
    }
}
