using Planetarium;
using System.Numerics;

namespace PlanetariumBlazor.Internal
{
    public class Planet : ISpaceObject
    {
        public Vector3 Speed { get; set; }
        public Vector3 Position { get; set; }
        public double Weight { get; set; }
    }
}