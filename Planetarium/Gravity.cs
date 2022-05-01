using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Planetarium
{
    public class Gravity : IGravity
    {

        public Gravity(double g = DEFAULT_G)
        {
            G = g;
        }

        public const double DEFAULT_G = 6.7385E-11;

        public double G { get; }

        public Task RecalculateAllSpeeds(IUniverse universe)
        {
            var planets = universe.Objects.OfType<ISpaceObject>().ToList();

            if (planets.Count() < 2)
                return Task.CompletedTask;

            planets.AsParallel().Select(planet =>
            {
                var sum = planets.Where(p => p != planet)
                    .Select(p => GetGravitySpeedToObject(planet, p))
                    .Aggregate((v, r) => Vector3.Add(v, r));
                planet.Speed = Vector3.Add(planet.Speed, sum);

                return planet.Speed;
            }).ToArray();

            return Task.CompletedTask;
        }

        private Vector3 GetGravitySpeedToObject(ISpaceObject from, ISpaceObject to)
        {
            var gravityForce = GetForceOfGravity(from, to);
            var substraction = Vector3.Subtract(to.Position, from.Position);
            var gravityVector = Vector3.Multiply(substraction, gravityForce);
            var withInertia = Vector3.Multiply(gravityVector, 1 / (float)from.Weight);

            return withInertia;
        }

        private float GetForceOfGravity(ISpaceObject obj1, ISpaceObject obj2)
        {
            var distance = Vector3.Distance(obj1.Position, obj2.Position);

            var result = G * (obj1.Weight * obj2.Weight) / Math.Pow(distance, 2);

            return (float)result;
        }

    }

}
