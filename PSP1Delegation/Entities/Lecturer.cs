using System;

namespace PSP1Delegation.Entities
{
    class Lecturer
    {
        private DateTime _joinedDate;
        public string[] Distractions { get; set; }
        public double AttendancePercent { get; set; }
        public bool IsUniversityMainActivity { get; set; }

        public void SetJoinedDate(DateTime date)
        {
            _joinedDate = date;
        }

        public DateTime GetJoinedDate()
        {
            return _joinedDate;
        }
    }
}
