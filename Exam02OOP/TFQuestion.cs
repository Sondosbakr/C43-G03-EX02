using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal class TFQuestion : Question
    {
        public TFQuestion(string? header, string? body, int mark, Answer[]? answerList, Answer correctAnswer) : base(header, body, mark, answerList)
        {
            CorrectAnswer = correctAnswer;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}: (Mark {Mark})");
            foreach (var answer in AnswerList)
            {
                Console.Write($"{answer.AnswerId}-{answer.AnswerText}   ");
            }
        }
    }
}
