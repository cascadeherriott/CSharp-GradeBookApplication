using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5)
            { throw new InvalidOperationException("You must have 5 students to do a ranked grading."); }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[threshold - 1])
                return 'A';
            if (averageGrade >= grades[(threshold * 2) - 1])
                return 'B';
            if (averageGrade>= grades[(threshold*3)-1])
                    return 'C';
            if (averageGrade >= grades[(threshold * 4) - 1])
                return 'D';
            return 'F';

        }

        public override void CalculateStatistics()
        {
            if(Students.Count>4)
                base.CalculateStatistics();
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count > 4)
                base.CalculateStudentStatistics(name);
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
        }
    } 
}
