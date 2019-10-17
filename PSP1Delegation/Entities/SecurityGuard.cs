using System;

namespace PSP1Delegation.Entities
{
    class SecurityGuard
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

        public double GetRiskOfBeingFired()
        {
            if (Distractions.Length == 0) { return 0; }
            else { return Distractions.Length * 8; }
        }
    }
}
