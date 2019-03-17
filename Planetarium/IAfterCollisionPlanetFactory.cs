using System.Collections.Generic;

namespace Planetarium
{
    public interface IAfterCollisionPlanetFactory<T>
        where T : IPlanet
    {

        T Alloy(IEnumerable<T> planets);

    }
}
