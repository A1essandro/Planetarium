using System;
using System.Collections.Generic;
using System.Linq;

namespace Planetarium
{

    /// <summary>
    /// Encapsulates logic of collision calculation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class CollisionManager<T>
        where T : IPlanet
    {

        private readonly Func<IEnumerable<T>, T> _factory;

        public CollisionManager(Func<IEnumerable<T>, T> factory)
        {
            _factory = factory;
        }

        public CollisionManager(IAfterCollisionPlanetFactory<T> factory)
            : this(factory.Alloy)
        {
        }

        /// <summary>
        /// Check each object to collision with others
        /// </summary>
        /// <param name="planets"></param>
        /// <returns></returns>
        public CheckResult CheckCollisions(IEnumerable<T> planets)
        {
            var result = new CheckResult();
            var toCheck = planets.OrderByDescending(p => p.Mass).ToList(); //copy
            while (toCheck.Count() > 1)
            {
                var planet = toCheck[0];
                toCheck.RemoveAt(0);

                var others = planets.Where(p => !ReferenceEquals(p, planet));
                var collisions = others.Where(p => _checkCollision(planet, p)).ToList();
                if (!collisions.Any()) continue;

                toCheck.RemoveAll(p => collisions.Contains(p));

                collisions.Add(planet);
                result.NewObjects.Add(_factory(collisions));
                result.DestroyedObjects.AddRange(collisions);
            }

            return result;
        }

        private bool _checkCollision(T planet1, T planet2)
        {
            var range = Math.Sqrt(Math.Pow(planet1.Position.X - planet2.Position.X, 2) + Math.Pow(planet1.Position.Y - planet2.Position.Y, 2));
            var radiusSum = planet1.Radius + planet2.Radius;

            return range <= radiusSum;
        }

        /// <summary>
        /// Result of calculation of collisions check
        /// </summary>
        public class CheckResult
        {

            /// <summary>
            /// Objects which created after collisions
            /// </summary>
            public List<T> NewObjects { get; set; } = new List<T>();

            /// <summary>
            /// Objects which destroyed after collisions
            /// </summary>
            public List<T> DestroyedObjects { get; set; } = new List<T>();

        }

    }
}
