using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Planetarium
{
    public class UniverseTime : IUniverseTime
    {

        private readonly IGravity _gravity;

        public UniverseTime(IGravity gravity)
        {
            _gravity = gravity;
        }

        public async Task Tick(IUniverse universe)
        {
            await _gravity.RecalculateAllSpeeds(universe);

            foreach (var planet in universe.Objects.OfType<IMovable>())
            {
                planet.Position = Vector3.Add(planet.Position, planet.Speed);
            }
        }

    }

}
