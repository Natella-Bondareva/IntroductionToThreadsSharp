using System;
using System.Collections.Generic;
using System.Threading;

namespace IntroductionToThreads
{
    public class ThreadManager
    {
        private readonly List<StopSignal> _signals;
        private readonly int[][] _delays;

        public ThreadManager(List<StopSignal> signals, int[][] delays)
        {
            _signals = signals;
            _delays = delays;
        }

        public void Run()
        {
            for (int i = 0; i < _delays.Length; i++)
            {
                int waitTime;
                if (i == 0)
                    waitTime = _delays[i][0];
                else
                    waitTime = _delays[i][0] - _delays[i - 1][0]; 

                Thread.Sleep(waitTime);
                int index = _delays[i][1]; // індекс сигналу
                _signals[index].RequestStop();
            }
        }
    }
}
