using System.Diagnostics;

namespace Exam02OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Sub01 = new Subject(10, "C#");
            Sub01.CreateExam();
            Console.Clear();
            Console.WriteLine("Do You Want To Start Exam (Y / N)");


            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();
                Sub01.Exam?.ShowExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
        }
    }
}
