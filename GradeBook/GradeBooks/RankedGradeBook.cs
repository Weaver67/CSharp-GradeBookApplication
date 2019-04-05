using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name)
            :base(name)
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
    }
}
