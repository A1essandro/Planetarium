using Planetarium;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlanetariumWpf.Model
{
    internal sealed class Universe : INotifyPropertyChanged
    {

        public Gravity Gravity { get; }

        public CollisionManager<Planet> CollisionManager;

        public Universe(Gravity gravity, CollisionManager<Planet> collisionManager)
        {
            Gravity = gravity;
            CollisionManager = collisionManager;
        }

        public ObservableCollection<IPlanet> Entities { get; set; } = new ObservableCollection<IPlanet>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
