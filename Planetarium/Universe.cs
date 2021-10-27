using System.Collections.Generic;

namespace Planetarium
{
    public class Universe<TCoordinates> : IUniverse<TCoordinates> where TCoordinates : class, ICoordinates
    {

        public ICollection<object> Objects { get; set; }

    }

}
