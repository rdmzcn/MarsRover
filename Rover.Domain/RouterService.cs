using System.Linq;

namespace Rover.Domain
{
    using System.Collections.Generic;
    using Rover.Domain.Models;

    public class RouterService
    {
        public RouterService(Plateau plateau)
        {
            Plateau = plateau;
        }

        private Plateau Plateau { get; }

        public IEnumerable<Rover> Route(List<RoverRouter> roverRouters)
        {
            foreach (var roverRouter in roverRouters)
            {
                var rover = roverRouter.Rover;
                var movements = roverRouter.Movements;

                foreach (var movement in movements)
                {
                    if (!this.WillTheRoverFall(rover, movement))
                    {
                        rover.Move(movement);
                    }
                }
            }

            return roverRouters.Select(rr => rr.Rover);
        }

        private bool WillTheRoverFall(Rover rover, Movement movement)
        {
            var roverNextPosition = rover.GetNextLocation(movement);
            return roverNextPosition.X < this.Plateau.StartCoordinate.X || roverNextPosition.X > this.Plateau.EndCoordinate.X
                   || roverNextPosition.Y < this.Plateau.StartCoordinate.Y || roverNextPosition.Y > this.Plateau.EndCoordinate.Y;
        }
    }
}