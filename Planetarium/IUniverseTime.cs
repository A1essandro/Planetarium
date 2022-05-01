using System.Threading.Tasks;

namespace Planetarium
{
    public interface IUniverseTime : IUniverseProperty
    {

        Task Tick(IUniverse universe);

    }

}
