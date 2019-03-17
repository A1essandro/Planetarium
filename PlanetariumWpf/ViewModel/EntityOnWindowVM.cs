using Planetarium;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlanetariumWpf.ViewModel
{
    public sealed class EntityOnWindowVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<IPlanet> Entities { get; set; } = new ObservableCollection<IPlanet>();

    }
}
