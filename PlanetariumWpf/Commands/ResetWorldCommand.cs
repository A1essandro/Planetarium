using Planetarium;
using System.Collections.Generic;

namespace PlanetariumWpf.Commands
{
    internal class ResetWorldCommand : EntitiesCommandBase
    {

        public ResetWorldCommand(ICollection<IPlanet> entities)
            : base(entities)
        {
        }

        public override bool CanExecute(object parameter) => entities.Count > 0;

        public override void Execute(object parameter)
        {
            entities.Clear();
        }

    }
}
