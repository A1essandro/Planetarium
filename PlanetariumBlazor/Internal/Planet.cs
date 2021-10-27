using Planetarium;

namespace PlanetariumBlazor.Internal
{
    public class Planet : ISpaceObject<Coordinates2D>
    {
        public Coordinates2D Speed { get; set; }
        public Coordinates2D Position { get; set; }
        public double Weight { get; set; }
    }
}