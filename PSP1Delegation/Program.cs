using PSP1Delegation.Components;
using System;

namespace PSP1Delegation
{
    class Program
    {
        static void Main(string[] args)
        {
            var regularStudent = new RegularAttendanceBasicRewardStudent(new RegularAttendancePolicy(), new BasicRewardPolicy(), new YearsInUniversityCalculator());
            string[] distractions = new string[] { "is tired", "after vacation", "lazy" };
            regularStudent.SetJoinedDate(new DateTime(2017, 09, 01));
            regularStudent.Distractions = distractions;
            regularStudent.IsUniversityMainActivity = false;
            regularStudent.AttendancePercent = 95;

            Console.WriteLine("Chance of attendance is " + regularStudent.CalculateChanceOfAttendance(regularStudent.Distractions, regularStudent.IsUniversityMainActivity));
            Console.WriteLine("Chance of scholarship is " + regularStudent.CalculateRewardChance(regularStudent.AttendancePercent));

            var securityGuard = new RegularAttendanceBasicRewardSecurityGuard(new RegularAttendancePolicy(), new BasicRewardPolicy(), new YearsInUniversityCalculator());
            distractions = new string[] { "likes television", "plays computer games" };
            securityGuard.SetJoinedDate(new DateTime(2015, 03, 04));
            securityGuard.Distractions = distractions;
            securityGuard.IsUniversityMainActivity = true;
            securityGuard.AttendancePercent = 100;

            Console.WriteLine("\nChance of attendance is " + securityGuard.CalculateChanceOfAttendance(securityGuard.Distractions, securityGuard.IsUniversityMainActivity));
            Console.WriteLine("Chance of reward is " + securityGuard.CalculateRewardChance(securityGuard.AttendancePercent));
            Console.WriteLine("Chance of getting fired is " + securityGuard.GetRiskOfBeingFired());

            Console.ReadKey();
        }
    }
}
