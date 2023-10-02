using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppGame
{
    class Timer
    {
        public float Interval { get; set; }
        public bool AutoReset { get; set; }

        public void Start()
        {
            
        }

        public void ElapsedTime()
        {
            var _previousTime = DateTime.Now;
            var _nowTime = DateTime.Now;

            TimeSpan elapsed = _nowTime - _previousTime;

        }

    }
}
