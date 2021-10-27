namespace Planetarium
{
    public interface IPositioned<TCoordinates> where TCoordinates : ICoordinates
    {

        TCoordinates Position { get; set; }

    }

}
