using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Text;

namespace TimeSystem.Domain
{
    public static class Timer
    {
        static Stopwatch stopWatch = new Stopwatch();

        public static void Start()
        {
            stopWatch.Start();
        }

        public static TimeSpan Stop()
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return ts;
        }
    }
}
