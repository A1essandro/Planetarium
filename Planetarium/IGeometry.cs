namespace Planetarium
{

    public interface IGeometry<TCoordinates> : IUniverseProperty<TCoordinates> where TCoordinates : class, ICoordinates
    {

        double GetDistance(TCoordinates point1, TCoordinates point2);

        double GetLenght(TCoordinates vector);

        TCoordinates VectorSubstruct(TCoordinates v1, TCoordinates v2);

        TCoordinates VectorAdd(TCoordinates v1, TCoordinates v2);

        TCoordinates VectorMultiply(TCoordinates vector, double factor);

    }

}
