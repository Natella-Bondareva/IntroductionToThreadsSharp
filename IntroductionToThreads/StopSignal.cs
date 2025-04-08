using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToThreads
{
    public class StopSignal
    {
        private volatile bool _stop = false;

        public void RequestStop() => _stop = true;

        public bool ShouldStop => _stop;
    }
}
