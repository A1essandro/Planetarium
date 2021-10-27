using System.Threading.Tasks;

namespace Planetarium
{

    public interface IGravity<TCoordinates> : IUniverseProperty<TCoordinates> where TCoordinates : class, ICoordinates
    {

        Task RecalculateAllSpeeds(IUniverse<TCoordinates> universe);

    }

}
