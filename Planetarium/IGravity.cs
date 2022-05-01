using System.Threading.Tasks;

namespace Planetarium
{

    public interface IGravity : IUniverseProperty
    {

        Task RecalculateAllSpeeds(IUniverse universe);

    }

}
