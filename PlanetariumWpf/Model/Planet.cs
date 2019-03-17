using Planetarium;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PlanetariumWpf.Model
{
    public class Planet : Entity, IPlanet
    {

        public Vector Speed { get; set; }

        public double Radius => Size / 2;

        public Planet(double size, Point point)
            : base(size, point, GetColor())
        {
            Speed = new Vector(0, 0);
        }

        public void Move() => point += Speed;

        public override Shape GetRenderElement()
        {
            var sizeYOffset = Radius + 40; // 40 - TextBlock heigth + button
            return new Ellipse
            {
                Fill = new SolidColorBrush(Color),
                Height = Size,
                Width = Size,
                Margin = new Thickness(Position.X * WorldState.Scale - Radius, Position.Y * WorldState.Scale - sizeYOffset, 0, 0)
            };
        }

        private static Color GetColor() => Color.FromArgb(255, 255, 255, 0);
    }
}
