using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int time, int numberOfQuestion, Question[] questions) : base(time, numberOfQuestion, questions)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("------------------------- Practical Exam ------------------------");
            Dictionary<string, string> questionResult = new Dictionary<string, string>();

            if (Questions == null || Questions.Length == 0)
            {
                Console.WriteLine("No questions available for this exam.");
                return;
            }
            int score = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                Questions[i].Display();

                string questionBody = Questions[i]?.Body ?? "Unknown Question";
                string rightAnswer = Questions[i].CorrectAnswer?.AnswerText ?? "No Correct Answer";
                questionResult[questionBody] = rightAnswer;

                bool isParsed;
                int userAnswer;
                do
                {
                    Console.Write($"Please Enter Your Answer: ");
                    isParsed = int.TryParse(Console.ReadLine(), out userAnswer);
                } while (!isParsed);

                if(userAnswer == Questions[i]?.CorrectAnswer?.AnswerId)
                {
                    score += Questions[i].Mark;
                }
            }
            foreach (var item in questionResult)
            {
                Console.WriteLine($"Question: {item.Key}");
                Console.WriteLine($"Correct Answer {item.Value}");
                Console.WriteLine("-------------------------------------");
            }

        }
    }
}
