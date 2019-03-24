using Planetarium;
using PlanetariumWpf.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlanetariumWpf.ViewModel
{
    internal sealed class EntityOnWindowVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<IPlanet> Entities { get; set; } = new ObservableCollection<IPlanet>();

        public ResetWorldCommand ResetCommand => new ResetWorldCommand(Entities);

        public AddEntitiesCommand GenerateCommand => new AddEntitiesCommand(Entities);

        public ZoomCommand ZoomCommand => new ZoomCommand();

    }
}
