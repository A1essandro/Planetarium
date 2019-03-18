using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;
using VectorAndPoint.ValTypes;

namespace PlanetariumWpf.Model
{
    public abstract class Entity : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public Entity(double mass, Point position, Color color)
        {
            Mass = mass;
            Color = color;
            point = position;
        }

        protected Point point;

        public double Mass { get; }
        public double Size => Math.Sqrt(Mass) * WorldState.Scale;
        public Color Color { get; }
        public Point Position => point;

        public abstract Shape GetRenderElement();

    }
}
