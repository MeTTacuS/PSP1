using System;
using PSP1Template.Lecturer;

namespace PSP1Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // Student with regular attendance and Scholarship
            Console.WriteLine("Student");
            RegularAttendance_BasicScholarshipStudent regularStudent = new RegularAttendance_BasicScholarshipStudent();
            string[] distractions = new string[] { "is tired", "after vacation", "lazy" };
            regularStudent.SetDistractions(distractions);
            regularStudent.SetMainActivity(true);
            Console.WriteLine("Chance with regular attendance policy is " + regularStudent.CalculateChanceOfAttendance());
            regularStudent.SetAttendancePercent(95);
            Console.WriteLine("Chance of normal scholarship is " + regularStudent.CalculateChanceOfScholarship());

            // Lecturer with regular attendance
            Console.WriteLine("\nLecturer");
            RegularAttendanceLecturer regularLecutrer = new RegularAttendanceLecturer();
            regularLecutrer.SetDistractions(distractions);
            regularLecutrer.IsUniMainJob(true);
            regularLecutrer.SetLectures(3);
            Console.WriteLine("Chance with regular attendance policy is " + regularLecutrer.CalculateChanceOfAttendance());


            Console.ReadKey();
        }
    }
}
