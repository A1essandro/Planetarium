using System.Linq;
using System.Threading.Tasks;

namespace Planetarium
{
    public class UniverseTime<TCoordinates> : IUniverseTime<TCoordinates> where TCoordinates : class, ICoordinates
    {

        private readonly IGeometry<TCoordinates> _geometry;
        private readonly IGravity<TCoordinates> _gravity;

        public UniverseTime(IGeometry<TCoordinates> geometry, IGravity<TCoordinates> gravity)
        {
            _geometry = geometry;
            _gravity = gravity;
        }

        public async Task Tick(IUniverse<TCoordinates> universe)
        {
            await _gravity.RecalculateAllSpeeds(universe);

            foreach (var planet in universe.Objects.OfType<IMovable<TCoordinates>>())
            {
                planet.Position = _geometry.VectorAdd(planet.Position, planet.Speed);
            }
        }

    }

}
