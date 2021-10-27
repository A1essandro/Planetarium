using Planetarium;

namespace PlanetariumTest
{
    internal class Coordinates2D : I2D
    {

        public Coordinates2D() { }

        public Coordinates2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}