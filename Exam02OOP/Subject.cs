using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02OOP
{
    internal class Subject
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public Exam? Exam { get; set; }

        public Subject(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            bool isParsed;
            string? examType;
            do
            {
                Console.Write("Please Enter The Exam Type (Final / Practical): ");
                examType = Console.ReadLine()?.ToLower();
            } while (examType != "final" && examType != "practical");
            Console.WriteLine();

            int time;
            do
            {
                Console.Write("Please Enter the Time Of Exam: ");
                isParsed = int.TryParse(Console.ReadLine(), out time);
            } while (!isParsed);
            Console.WriteLine();

            int numberOfQuestion;
            do
            {
                Console.Write("Please Enter Number Of Questions: ");
                isParsed = int.TryParse(Console.ReadLine(), out numberOfQuestion);
            } while (!isParsed);
            Console.WriteLine();

            Question[] questions = new Question[numberOfQuestion];

            for (int i = 0; i < questions.Length; i++)
            {
                int typeOfQuestion;
                do
                {
                    Console.Write($"Please Enter the Type Of Questions {i+1}: ");
                    if(examType == "final")
                        Console.Write("(1 for TF, 2 for MCQ): ");
                    else
                        Console.Write("(Only 2 for MCQ): ");
                    isParsed = int.TryParse(Console.ReadLine(), out typeOfQuestion); 
                } while (!isParsed || (examType == "practical" && typeOfQuestion != 2) || (typeOfQuestion != 1 && typeOfQuestion != 2));
                Console.WriteLine();

                Console.Write("Please Enter Question Body: ");
                string? body = Console.ReadLine();
                Console.WriteLine();

                int mark;
                do
                {
                    Console.Write("Please Enter The Question Mark: ");
                    isParsed = int.TryParse(Console.ReadLine(), out mark);
                } while (!isParsed);
                Console.WriteLine();

                if (typeOfQuestion == 1) // True/False (Only for Final Exam)
                {
                    int correctAnswer;
                    do
                    {
                        Console.Write("Please Enter The Right Answer (1 for True, 2 for False): ");
                        isParsed = int.TryParse(Console.ReadLine(), out correctAnswer);
                    } while (!isParsed || (correctAnswer != 1 && correctAnswer != 2));
                    Console.WriteLine();
                    Answer[] answers =
                    {
                        new Answer(1, "True"),
                        new Answer(2, "False")
                    };

                    questions[i] = new TFQuestion("True/False Question: ", body, mark, answers, answers[correctAnswer - 1]);
                }
                else if (typeOfQuestion == 2)
                {
                    int choiceNumber;
                    do
                    {
                        Console.Write("Please Enter The Number Of Choices : ");
                        isParsed = int.TryParse(Console.ReadLine(), out choiceNumber);
                    } while (!isParsed);
                    Console.WriteLine();

                    Answer[] answers = new Answer[choiceNumber];

                    Console.WriteLine("-------------- Choices Of Question -------------");
                    for (int j = 0; j < choiceNumber; j++)
                    {
                        Console.Write($"Choice {j + 1}: ");
                        string? choice = Console.ReadLine();
                        Console.WriteLine();
                        answers[j] = new Answer(j + 1, choice);
                    }

                    int correctChoice;
                    do
                    {
                        Console.Write("Please Specify The Right Choice Of Question: ");
                        isParsed = int.TryParse(Console.ReadLine(), out correctChoice);
                    } while (!isParsed || correctChoice < 1 || correctChoice > choiceNumber);

                    questions[i] = new MCQQuestion("MCQ Quwstions", body, mark, answers);
                    questions[i].CorrectAnswer = answers[correctChoice - 1];
                }

            }
            if (examType == "final")
                Exam = new FinalExam(time, numberOfQuestion, questions);
            else
                Exam = new PracticalExam(time, numberOfQuestion, questions);


        }


    }
}
