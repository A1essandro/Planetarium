using System;

namespace Planetarium
{
    public class Geometry2D<TCoordinates> : IGeometry<TCoordinates>
        where TCoordinates : class, I2D, new()
    {

        public double GetDistance(TCoordinates point1, TCoordinates point2)
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }

        public double GetLenght(TCoordinates vector)
        {
            return Math.Sqrt(Math.Pow(vector.X, 2) + Math.Pow(vector.Y, 2));
        }

        #region Vector

        public TCoordinates VectorAdd(TCoordinates v1, TCoordinates v2)
        {
            return new TCoordinates
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y
            };
        }

        public TCoordinates VectorMultiply(TCoordinates vector, double factor)
        {
            return new TCoordinates
            {
                X = factor * vector.X,
                Y = factor * vector.Y
            };
        }

        public TCoordinates VectorSubstruct(TCoordinates v1, TCoordinates v2)
        {
            return new TCoordinates
            {
                X = v1.X - v2.X,
                Y = v1.Y - v2.Y
            };
        }

        #endregion

    }

}
