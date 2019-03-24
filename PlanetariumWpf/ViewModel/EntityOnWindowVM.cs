using Planetarium;
using PlanetariumWpf.Commands;
using PlanetariumWpf.Model;
using System.ComponentModel;

namespace PlanetariumWpf.ViewModel
{
    internal sealed class EntityOnWindowVM : INotifyPropertyChanged
    {

        public EntityOnWindowVM()
        {
            var gravity = new Gravity(0.001);
            Universe = new Universe(gravity, new CollisionManager<Planet>(new AfterCollisionPlanetFactory()));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Universe Universe { get; }

        public ResetWorldCommand ResetCommand => new ResetWorldCommand(Universe.Entities);

        public AddEntitiesCommand GenerateCommand => new AddEntitiesCommand(Universe.Entities);

        public ZoomCommand ZoomCommand => new ZoomCommand();
    }
}
