using PSP1;
using PSP1.ScholarshipConditions;
using System;

namespace PSP1Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main option - a student
            Console.WriteLine("Student Data");
            var student = new Student();
            string[] distractions = new string[] { "is tired", "after vacation", "lazy" };
            student.SetDistractions(distractions);
            student.SetMainActivity(true);

            // Regular policy
            var chance = student.CalculateChanceOfAttendance(new RegularAttendancePolicy());
            if (chance != -1)
                Console.WriteLine("Chance with regular attendance policy is " + chance);
            else
                Console.WriteLine("Attendance chance could not be calculated");

            // Policy that checks if a student is "lazy"
            chance = student.CalculateChanceOfAttendance(new LazyAttendancePolicy());
            if (chance != -1)
                Console.WriteLine("Chance is lazy attendance policy is " + chance);
            else
                Console.WriteLine("Attendance chance could not be calculated");

            // New variation
            student.SetAttendancePercent(95);
            Console.WriteLine("Chance of normal scholarship is " + student.CalculateChanceOfScholarship(new BasicScholarshipCalculator()));
            Console.WriteLine("Chance of harsh scholarship is " + student.CalculateChanceOfScholarship(new HarshScholarshipCalculator()));

            //=============================================================================//

            // New option - a lecturer
            Console.WriteLine("\nLecturer Data");
            var lecturer = new Lecturer();
            distractions = new string[] { "is tired", "after vacation", "lazy" };
            lecturer.SetDistractions(distractions);
            lecturer.IsUniMainJob(true);
            lecturer.SetLectures(3);

            // Regular policy
            chance = lecturer.CalculateChanceOfAttendance(new RegularAttendancePolicy());
            if (chance != -1)
                Console.WriteLine("Chance with regular attendance policy is " + chance);
            else
                Console.WriteLine("Attendance chance could not be calculated");

            // Policy that checks if a student is "lazy"
            chance = lecturer.CalculateChanceOfAttendance(new LazyAttendancePolicy());
            if (chance != -1)
                Console.WriteLine("Chance is lazy attendance policy is " + chance);
            else
                Console.WriteLine("Attendance chance could not be calculated");


            Console.ReadKey();
        }
    }
}
