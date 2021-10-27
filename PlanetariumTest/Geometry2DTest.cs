using Xunit;
using Planetarium;
using Shouldly;
using System;

namespace PlanetariumTest
{
    public class Geometry2DTest
    {

        [Fact]
        public void GetDistanceTest()
        {
            var geometry = new Geometry2D<Coordinates2D>();

            var result0 = geometry.GetDistance(new Coordinates2D(0, 0), new Coordinates2D(0, 0));
            var result1 = geometry.GetDistance(new Coordinates2D(0, 0), new Coordinates2D(0, 1));
            var result2 = geometry.GetDistance(new Coordinates2D(1, 0), new Coordinates2D(0, 0));
            var result3 = geometry.GetDistance(new Coordinates2D(1, 1), new Coordinates2D(2, 2));

            result0.ShouldBe(0);
            result1.ShouldBe(1);
            result2.ShouldBe(1);
            result3.ShouldBe(Math.Sqrt(2));
        }


        [Fact]
        public void GetLenghtTest()
        {
            var geometry = new Geometry2D<Coordinates2D>();

            var result0 = geometry.GetLenght(new Coordinates2D(0, 0));
            var result1 = geometry.GetLenght(new Coordinates2D(0, 1));
            var result2 = geometry.GetLenght(new Coordinates2D(1, 1));

            result0.ShouldBe(0);
            result1.ShouldBe(1);
            result2.ShouldBe(Math.Sqrt(2));
        }

        [Fact]
        public void VectorAddTest()
        {
            var geometry = new Geometry2D<Coordinates2D>();

            var result = geometry.VectorAdd(new Coordinates2D(-1, 1), new Coordinates2D(1, 1));

            result.X.ShouldBe(0);
            result.Y.ShouldBe(2);
        }

        [Fact]
        public void VectorSubstruct()
        {
            var geometry = new Geometry2D<Coordinates2D>();

            var result = geometry.VectorSubstruct(new Coordinates2D(-1, 1), new Coordinates2D(1, 1));

            result.X.ShouldBe(-2);
            result.Y.ShouldBe(0);
        }

        [Fact]
        public void VectorMultiply()
        {
            var geometry = new Geometry2D<Coordinates2D>();

            var result = geometry.VectorMultiply(new Coordinates2D(-1, 1), 2.5);

            result.X.ShouldBe(-2.5);
            result.Y.ShouldBe(2.5);
        }

    }
}
