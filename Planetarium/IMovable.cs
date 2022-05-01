using System.Numerics;

namespace Planetarium
{

    public interface IMovable : IPositioned
    {

        Vector3 Speed { get; set; }

    }

}
