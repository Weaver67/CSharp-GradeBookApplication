using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted)
            :base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            int numberOfStudentsToTakeDownLetterGrade = Students.Count / 5; //20% of the total number
            var numberOfStundentsWithTheAverageScoreHigheThanTheInput = Students.Count(student => student.AverageGrade > averageGrade);

            if (numberOfStundentsWithTheAverageScoreHigheThanTheInput < numberOfStudentsToTakeDownLetterGrade)
            {
                return 'A';
            }

            if (numberOfStundentsWithTheAverageScoreHigheThanTheInput >= numberOfStudentsToTakeDownLetterGrade 
                && numberOfStundentsWithTheAverageScoreHigheThanTheInput < numberOfStudentsToTakeDownLetterGrade * 2)
            {
                return 'B';
            }

            if (numberOfStundentsWithTheAverageScoreHigheThanTheInput >= numberOfStudentsToTakeDownLetterGrade * 2
                && numberOfStundentsWithTheAverageScoreHigheThanTheInput < numberOfStudentsToTakeDownLetterGrade * 3)
            {
                return 'C';
            }

            if (numberOfStundentsWithTheAverageScoreHigheThanTheInput >= numberOfStudentsToTakeDownLetterGrade * 3
                && numberOfStundentsWithTheAverageScoreHigheThanTheInput < numberOfStudentsToTakeDownLetterGrade * 4)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
