using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToThreads
{
    public class ThreadManager
    {
        private readonly List<StopSignal> _signals;
        private readonly int[] _delays;

        public ThreadManager(List<StopSignal> signals, int[] delays)
        {
            _signals = signals;
            _delays = delays;
        }

        public void Run()
        {
            List<Thread> timerThreads = new List<Thread>();

            for (int i = 0; i < _signals.Count; i++)
            {
                int index = i;
                Thread t = new Thread(() =>
                {
                    Thread.Sleep(_delays[index]);
                    _signals[index].RequestStop();
                });
                t.Start();
                timerThreads.Add(t);
            }

            //foreach (var t in timerThreads)
            //{
            //    t.Join();
            //}
        }
    }
}
