using System;
using System.Windows.Input;

namespace PlanetariumWpf.Commands
{
    internal class MoveByYCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        { 

        }
    }
}
