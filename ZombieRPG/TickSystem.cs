using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieRPG
{
    internal class TickSystem
    {
        private bool isRunning;
        private int tickIntervalMilliseconds;
        private Thread tickThread;

        public event Action OnTick;

        public TickSystem(int tickIntervalMilliseconds)
        {
            this.tickIntervalMilliseconds = tickIntervalMilliseconds;
            this.isRunning = false;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                tickThread = new Thread(DoTick);
                tickThread.Start();
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                tickThread.Join();
            }
        }

        private void DoTick()
        {
            while (isRunning)
            {
                OnTick?.Invoke();
                Thread.Sleep(tickIntervalMilliseconds);
            }
        }
    }

}
