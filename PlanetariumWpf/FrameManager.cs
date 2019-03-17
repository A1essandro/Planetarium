using System;
using System.Windows.Threading;

namespace PlanetariumWpf
{
    internal sealed class FrameManager
    {

        private const int MILLISECONDS = 5;

        private readonly DispatcherTimer _frameTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(MILLISECONDS) };

        public FrameManager(EventHandler perFrame, bool started = false)
        {
            _frameTimer.Tick += perFrame;
            if (started)
                Start();
        }

        public void Start() => _frameTimer.Start();

    }
}
