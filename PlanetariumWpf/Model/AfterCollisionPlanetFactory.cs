using Planetarium;
using System.Collections.Generic;
using System.Linq;

namespace PlanetariumWpf.Model
{
    internal sealed class AfterCollisionPlanetFactory : IAfterCollisionPlanetFactory<Planet>
    {

        public Planet Alloy(IEnumerable<Planet> planets)
        {
            var massSum = planets.Sum(x => x.Mass);
            var speed = planets.Select(p => p.Speed * (p.Mass / massSum))
                .Aggregate((v, r) => v + r);

            return new Planet(planets.Sum(x => x.Mass), planets.OrderByDescending(p => p.Mass).First().Position)
            {
                Speed = speed
            };
        }

    }
}
