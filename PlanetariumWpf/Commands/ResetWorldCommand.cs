using Planetarium;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PlanetariumWpf.Commands
{
    public class ResetWorldCommand : ICommand
    {

        private readonly ICollection<IPlanet> _entities;

        public ResetWorldCommand(ICollection<IPlanet> entities)
        {
            _entities = entities;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _entities.Clear();
        }

    }
}
