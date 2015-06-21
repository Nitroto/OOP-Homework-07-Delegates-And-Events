using System;

namespace AsynchronousTimer
{
    class AsynchronousTimerMain
    {
        static void Main()
        {
            AsyncTimer async1 = new AsyncTimer(CnahgeConsoleColor, 100, 1000);
            async1.Execute();
            AsyncTimer async2 = new AsyncTimer(Print, 200, 500);
            async2.Execute();
        }

        static void CnahgeConsoleColor()
        {
            Random rnd = new Random();
            var color = Enum.GetValues(typeof(ConsoleColor));
            Console.BackgroundColor = (ConsoleColor)color.GetValue(rnd.Next(color.Length));
        }
        static void Print()
        {
            Console.WriteLine("Test");
        }
    }
}
