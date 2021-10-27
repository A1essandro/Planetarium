using System.Threading.Tasks;

namespace Planetarium
{
    public interface IUniverseTime<TCoordinates> : IUniverseProperty<TCoordinates> where TCoordinates : class, ICoordinates
    {

        Task Tick(IUniverse<TCoordinates> universe);

    }

}
