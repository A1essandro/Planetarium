using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Planetarium
{
    public class Gravity<TCoordinates> : IGravity<TCoordinates> where TCoordinates : class, ICoordinates, new()
    {

        private readonly IGeometry<TCoordinates> _geometry;

        public Gravity(IGeometry<TCoordinates> geometry, double g = DEFAULT_G)
        {
            _geometry = geometry;
            G = g;
        }

        public const double DEFAULT_G = 6.7385E-11;

        public double G { get; }

        public Task RecalculateAllSpeeds(IUniverse<TCoordinates> universe)
        {
            var planets = universe.Objects.OfType<ISpaceObject<TCoordinates>>().ToList();

            if (planets.Count() < 2)
                return Task.CompletedTask;

            // foreach (var planet in planets)
            // {
            //     var sum = planets.Where(p => p.GetHashCode() != planet.GetHashCode())
            //         .Select(p => GetGravitySpeedToObject(planet, p))
            //         .Aggregate((v, r) => _geometry.VectorAdd(v, r));
            //     //planet.Speed = sum;// _geometry.VectorAdd(planet.Speed, sum);
            // }

            // return Task.CompletedTask;

            var tasks = planets.Select(planet => Task.Run(() =>
            {
                var sum = planets.Where(p => p != planet)
                    .Select(p => GetGravitySpeedToObject(planet, p))
                    .Aggregate((v, r) => _geometry.VectorAdd(v, r));
                planet.Speed = _geometry.VectorAdd(planet.Speed, sum);
            }));

            return Task.WhenAll(tasks);
        }

        private TCoordinates GetGravitySpeedToObject(ISpaceObject<TCoordinates> from, ISpaceObject<TCoordinates> to)
        {
            var gravityForce = GetForceOfGravity(from, to);
            var substraction = _geometry.VectorSubstruct(to.Position, from.Position);
            var gravityVector = _geometry.VectorMultiply(substraction, gravityForce);
            var withInertia = _geometry.VectorMultiply(gravityVector, 1 / from.Weight);

            return withInertia;
        }

        private double GetForceOfGravity(ISpaceObject<TCoordinates> obj1, ISpaceObject<TCoordinates> obj2)
        {
            var distance = _geometry.GetDistance(obj1.Position, obj2.Position);

            return G * (obj1.Weight * obj2.Weight) / Math.Pow(distance, 2);
        }

    }

}
