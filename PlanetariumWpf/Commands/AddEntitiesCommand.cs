using Planetarium;
using PlanetariumWpf.Model;
using System;
using System.Collections.Generic;

namespace PlanetariumWpf.Commands
{

    internal class AddEntitiesCommand : EntitiesCommandBase
    {

        public AddEntitiesCommand(ICollection<IPlanet> entities)
            : base(entities)
        {
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var rand = new Random();
            for (var i = 0; i < 100; i++)
            {
                var size = rand.Next() % 9 + 1;
                var point = new VectorAndPoint.ValTypes.Point(rand.Next() % 1500, rand.Next() % 800);
                entities.Add(new Planet(size, point));
            }
        }
    }

}
