using System;

namespace InterestCalculator
{
    public delegate decimal CalculateInterest(decimal sumOfMoney, decimal interest, int years);

    class InterestCalculator
    {
        private decimal interestRate;
        private int years;
        private CalculateInterest calculateInterest;

        public InterestCalculator(decimal sumOfMoney, decimal interest, int years, CalculateInterest calculateInterest)
        {
            this.SumOfMoney = sumOfMoney;
            this.InterestRate = interest;
            this.Years = years;
            this.calculateInterest = calculateInterest;
        }

        public decimal SumOfMoney { get; protected set; }
        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0M)
                {
                    throw new ArgumentOutOfRangeException("interestRate", "Interest rate cannot be negative!");
                }
                this.interestRate = value;
            }
        }
        public int Years
        {
            get
            {
                return this.years;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("years", "Years cannot be negative!");
                }
                this.years = value;
            }
        }
        public decimal Interest
        {
            get
            {
                return this.calculateInterest(this.SumOfMoney, this.InterestRate, this.Years);
            }
        }
    }
}
