using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string? header, string? body, int mark, Answer[]? answerList) : base(header, body, mark, answerList)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}: {Body}: (Mark {Mark})");
            foreach (var answer in AnswerList)
            { 
                Console.WriteLine($"{answer.AnswerId}-{answer.AnswerText}   ");
            }
        }
    }
}
