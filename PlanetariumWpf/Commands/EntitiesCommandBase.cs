using Planetarium;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PlanetariumWpf.Commands
{
    internal abstract class EntitiesCommandBase : ICommand
    {

        protected readonly ICollection<IPlanet> entities;

        protected EntitiesCommandBase(ICollection<IPlanet> entities)
        {
            this.entities = entities;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
