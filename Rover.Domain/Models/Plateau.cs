namespace Rover.Domain.Models
{
    public class Plateau
    {
        public Plateau(Coordinate startCoordinate, Coordinate endCoordinate)
        {
            StartCoordinate = startCoordinate;
            EndCoordinate = endCoordinate;
        }

        public Coordinate StartCoordinate{ get; }

        public Coordinate EndCoordinate { get; }
    }
}