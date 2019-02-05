using System;
using System.Diagnostics;

namespace ProfilerManiac.Utils
{
    public class Timer
    {
        private Stopwatch stopwatch;

        public Timer() => this.stopwatch = new Stopwatch();

        public void StartRunning()
        {
            this.stopwatch.Start();
        }

        public double StopRunning()
        {
            this.stopwatch.Stop();
            double elapsedTime = this.ElapsedTimeInMilliseconds();
            this.stopwatch.Reset();
            return elapsedTime;
        }

        private double ElapsedTimeInMilliseconds()
        {
            return this.stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
