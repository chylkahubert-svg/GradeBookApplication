using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
        public class RankedGradeBook : BaseGradeBook
        {
            public RankedGradeBook(string name, bool isWeighted)
                : base(name, isWeighted)
            {
                Type = GradeBookType.Ranked;
            }

            public override char GetLetterGrade(double averageGrade)
            {
                if (Students.Count < 5)
                    throw new InvalidOperationException("Ranked grading requires at least 5 students.");

                int threshold = (int)Math.Ceiling(Students.Count * 0.2);
                var grades = Students
                    .Select(s => s.AverageGrade)
                    .OrderByDescending(g => g)
                    .ToList();

                if (averageGrade >= grades[threshold - 1]) return 'A';
                if (averageGrade >= grades[(threshold * 2) - 1]) return 'B';
                if (averageGrade >= grades[(threshold * 3) - 1]) return 'C';
                if (averageGrade >= grades[(threshold * 4) - 1]) return 'D';
                return 'F';
            }

            public override void CalculateStatistics()
            {
                if (Students.Count < 5)
                {
                    Console.WriteLine("Ranked grading requires at least 5 students.");
                    return;
                }

                base.CalculateStatistics();
            }

            public override void CalculateStudentStatistics(string name)
            {
                if (Students.Count < 5)
                {
                    Console.WriteLine("Ranked grading requires at least 5 students.");
                    return;
                }

                base.CalculateStudentStatistics(name);
            }
        }


}
