namespace Planetarium
{
    public interface IUniverseObject<TCoordinates> : IMovable<TCoordinates>, ISpaceObject<TCoordinates>, IWeightedObject
        where TCoordinates : class, ICoordinates
    {

    }

}
