using System;
using System.Threading;

namespace AsynchronousTimer
{
    class AsyncTimer
    {
        private int ticks;
        private int timeInterval;

        public AsyncTimer(Action method, int ticks, int timeInterval)
        {
            this.Method = method;
            this.Ticks = ticks;
            this.TimeInterval = timeInterval;
        }

        public int Ticks
        {
            get
            {
                return this.ticks;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("ticks", "Ticks should be greater than 0.");
                }
                this.ticks = value;
            }
        }
        public int TimeInterval
        {
            get
            {
                return this.timeInterval;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("timeInterval", "Time interval should be greater than 0.");
                }
                this.timeInterval = value;
            }
        }
        public Action Method { get; private set; }

        public void Execute()
        {
            Thread parallel = new Thread(this.Run);
            parallel.Start();
        }
        private void Run()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                this.Method();
                Thread.Sleep(this.TimeInterval);
            }
        }
    }
}
