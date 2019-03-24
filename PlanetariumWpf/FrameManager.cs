using PlanetariumWpf.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlanetariumWpf
{
    internal sealed class FrameManager
    {

        private const int MILLISECONDS = 5;

        private readonly DispatcherTimer _frameTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(MILLISECONDS) };
        private readonly Universe _universe;

        public FrameManager(Universe universe, EventHandler visualize, bool started = false)
        {
            _universe = universe;

            _frameTimer.Tick += _calculate;
            _frameTimer.Tick += visualize;
            if (started)
                Start();
        }

        private async void _calculate(object sender, EventArgs e)
        {
            var planets = _universe.Entities.OfType<Planet>();
            await Task.Run(() => _universe.Gravity.RecalculateSpeed(planets));

            var collisionsResult = _universe.CollisionManager.CheckCollisions(planets);
            foreach (var toRemove in collisionsResult.DestroyedObjects)
                _universe.Entities.Remove(toRemove);
            foreach (var toAdd in collisionsResult.NewObjects)
                _universe.Entities.Add(toAdd);
        }

        public void Start() => _frameTimer.Start();

    }
}
