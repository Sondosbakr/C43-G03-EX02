using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal abstract class Exam
    {
        public int Time {  get; set; }
        public int NumberOfQuestion {  get; set; }
        public Question[]? Questions { get; set; }

        public Exam(int time, int numberOfQuestion, Question[] questions)
        {
            Time = time;
            NumberOfQuestion = numberOfQuestion;
            Questions = questions;
        }

        public abstract void ShowExam();
    }
}
