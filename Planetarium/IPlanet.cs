using VectorAndPoint.ValTypes;

namespace Planetarium
{
    public interface IPlanet
    {

        double Mass { get; }

        double Radius { get; }

        Vector Speed { get; set; } //TODO System.Windows!

        Point Position { get; } //TODO System.Windows!

    }
}
