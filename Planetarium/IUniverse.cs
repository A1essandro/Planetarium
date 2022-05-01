using System.Collections.Generic;

namespace Planetarium
{

    public interface IUniverse
    {

        ICollection<object> Objects { get; set; }

    }

}
