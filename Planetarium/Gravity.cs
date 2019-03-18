using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using VectorAndPoint.ValTypes;

namespace Planetarium
{

    /// <summary>
    /// Encapsulates logic of gravity calculation
    /// </summary>
    public sealed class Gravity
    {

        public Gravity(double g)
        {
            G = g;
        }

        public double G { get; set; }

        /// <summary>
        /// Change speed of each planet according to gravity calculation
        /// </summary>
        /// <param name="planets"></param>
        public void RecalculateSpeed(IEnumerable<IPlanet> planets)
        {
            Debug.Assert(planets != null, nameof(planets));

            planets = planets.ToList(); //copy

            if (planets.Count() < 2)
                return;

            using (var cache = new GravityCache())
            {
                foreach (var planet in planets)
                {
                    var sum = planets.Where(p => p != planet)
                                .Select(p => _getGravitySpeedToObject(cache, planet, p))
                                .Aggregate((v, r) => v + r);
                    planet.Speed += sum;
                }
            }
        }

        /// <summary>
        /// Calculate the gravity between the planets
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public double GetGravity(IPlanet from, IPlanet to)
        {
            Debug.Assert(from != null, nameof(from));
            Debug.Assert(to != null, nameof(to));

            var r2 = Math.Pow(from.Position.X - to.Position.X, 2) + Math.Pow(from.Position.Y - to.Position.Y, 2);
            return G * from.Mass * to.Mass / r2;
        }

        private Vector _getGravitySpeedToObject(GravityCache cache, IPlanet from, IPlanet to)
        {
            double gravity;
            if (cache.ContainsKey(from, to))
                gravity = cache.Get(from, to);
            else
            {
                gravity = GetGravity(from, to);
                cache.Set(from, to, gravity);
            }

            var speed = new Vector(gravity * (to.Position.X - from.Position.X), gravity * (to.Position.Y - from.Position.Y));

            var withInertia = speed * (1 / from.Mass);
            return withInertia;
        }

    }
}
