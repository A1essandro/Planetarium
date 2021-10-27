namespace Planetarium
{

    public interface IMovable<TCoordinates> : IPositioned<TCoordinates> where TCoordinates : ICoordinates
    {

        TCoordinates Speed { get; set; }

    }

}
