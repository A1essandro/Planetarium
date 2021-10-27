using System.Collections.Generic;

namespace Planetarium
{

    public interface IUniverse<TCoordinates> where TCoordinates : class, ICoordinates
    {

        ICollection<object> Objects { get; set; }

    }

}
