using System;
using System.Collections.Generic;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IntroductionToThreads
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            int[] delays = { 5000, 8000, 3000, 5000, 10000, 2000, 9000 };
            double[] steps = { 1, 2, 3, 4, 5, 6, 7 };

            List<StopSignal> signals = new List<StopSignal>();
            List<Thread> threads = new List<Thread>();

            int[][] indexedArray = delays
                .Select((value, index) => new int[] { value, index }) 
                .OrderBy(item => item[0]) 
                .ToArray();

            for (int i = 0; i < delays.Length; i++)
            {
                var signal = new StopSignal();
                signals.Add(signal);

                int id = i + 1;
                double step = steps[i];

                Thread thread = new Thread(() => Addder(id, step, signal));
                threads.Add(thread);
                thread.Start();
            }

            ThreadManager manager = new ThreadManager(signals, indexedArray);
            Thread managerThread = new Thread(manager.Run);
            managerThread.Start();

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            //managerThread.Join();
            Console.WriteLine("Main out");
        }
        static void Addder(int id, double step, StopSignal signal)
        {
            double sum = 0;
            double count = 0;

            while (!signal.ShouldStop)
            {
                sum += step;
                count++;
                Thread.Sleep(1);
            }

            Console.WriteLine($"Потік {id}: сума = {sum}, доданків = {count}");
        }
    }
}


