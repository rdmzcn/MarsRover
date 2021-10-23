namespace Rover.Domain.Models
{
    using System.Collections.Generic;

    public class RoverRouter
    {
        public RoverRouter(Rover rover, IEnumerable<Movement> movements)
        {
            Rover = rover;
            Movements = movements;
        }

        public Rover Rover { get; }

        public IEnumerable<Movement> Movements { get; }
    }
}