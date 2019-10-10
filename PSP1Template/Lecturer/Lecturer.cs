using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSP1Template.Lecturer
{
    abstract class Lecturer
    {
        private bool _isUniversityTheOnlyJob;
        private string[] _distratctions;
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

        protected abstract bool CheckUniqueness(string[] distractions);
        protected abstract double AdjustIfMainActivity(bool isMain, double chance);
        protected abstract double ChanceOfAttendance(string[] distractions, bool isMain, double chance);
        public double CalculateChanceOfAttendance()
        {
            double chance = 100;

            if (_amountOfLectures >= 3)
            {
                chance *= 0.8;
                if (CheckUniqueness(_distratctions))
                    return ChanceOfAttendance(_distratctions, _isUniversityTheOnlyJob, chance);
                else
                    return -1;
            }
            else
            {
                if (CheckUniqueness(_distratctions))
                    return ChanceOfAttendance(_distratctions, _isUniversityTheOnlyJob, chance);
                else
                    return -1;
            }
        }
    }
}
