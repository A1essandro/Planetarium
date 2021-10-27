namespace Planetarium
{

    public interface ISpaceObject<TCoordinates> : IMovable<TCoordinates>, IWeightedObject
        where TCoordinates : ICoordinates
    {

    }

}
