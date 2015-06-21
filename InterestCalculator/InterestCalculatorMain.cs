using System;

namespace InterestCalculator
{
    class InterestCalculatorMain
    {
        private const int N = 12;

        static void Main()
        {
            InterestCalculator compoundInterest = new InterestCalculator(500M, 5.6M, 10, GetCompoundInterest);
            InterestCalculator simpleInterest = new InterestCalculator(2500M, 7.2M, 15, GetSimpleInterest);
            Console.WriteLine("{0:F4}", compoundInterest.Interest);
            Console.WriteLine("{0:F4}", simpleInterest.Interest);
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            decimal a = 1;
            decimal baseInterest = (1 + ((interest/100) / N));
            int power = years * N;
            for (int i = 0; i < power; i++)
            {
                a *= baseInterest;
            }
            a *= sum;
            return a;
        }
        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            decimal a = sum * (1 + ((interest / 100) * years));
            return a;
        }
    }
}
