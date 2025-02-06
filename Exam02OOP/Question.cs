using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal class Question
    {

        public string? Header { get; set; }
        public string? Body { get;set; }
        public int Mark {  get; set; }

        public Answer[]? AnswerList { get; set; }    
        public Answer? CorrectAnswer { get; set; }   

        public abstract Question(string? header, string? body, int mark, Answer[]? answerList)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
        }

        public abstract void Display();
    }
}
