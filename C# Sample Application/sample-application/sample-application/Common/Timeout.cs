using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleApp.Common
{
    public class Timeout
    {
        private readonly int timeoutMilliseconds;
        private Stopwatch stopWatch;

        public Timeout(double timeoutMinutes)
        {
            timeoutMilliseconds = (int) (timeoutMinutes * 60000);
        }

        public void Start()
        {
            stopWatch = Stopwatch.StartNew();
        }

        public bool IsExpired()
        {
            bool isExpired = stopWatch.ElapsedMilliseconds >= timeoutMilliseconds;
            if (isExpired)
                stopWatch.Stop();
            return isExpired;
        }

    }
}
