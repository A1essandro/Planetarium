using Planetarium;
using System.Windows.Media;
using System.Windows.Shapes;
using VectorAndPoint.ValTypes;

namespace PlanetariumWpf.Model
{
    public class Planet : Entity, IPlanet
    {

        public Vector Speed { get; set; }

        public double Radius => Size / 2;

        public Planet(double size, Point point)
            : this(size, point, new Vector(0, 0))
        {
        }

        public Planet(double size, Point point, Vector speed)
            : base(size, point, GetColor())
        {
            Speed = speed;
        }

        public void Move() => point += Speed;

        public void Move(Vector speed) => point += speed;

        public override Shape GetRenderElement()
        {
            var sizeYOffset = Radius + 40; // 40 - TextBlock heigth + button
            return new Ellipse
            {
                Fill = new SolidColorBrush(Color),
                Height = Size,
                Width = Size,
                Margin = new System.Windows.Thickness(Position.X * WorldState.Scale - Radius, Position.Y * WorldState.Scale - sizeYOffset, 0, 0)
            };
        }

        private static Color GetColor() => Color.FromArgb(255, 255, 255, 0);
    }
}
