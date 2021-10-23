using System.Linq;

namespace Rover.Domain.Extensions
{
    using System.Collections.Generic;
    using Models;

    public static class StringExtensions
    {
        private static readonly Dictionary<string, Movement> MovementsDict = new Dictionary<string, Movement>() {{"M", Movement.MoveForward}, {"L", Movement.TurnLeft}, {"R", Movement.TurnRight}};
        private static readonly Dictionary<string, Direction> DirectionsDict = new Dictionary<string, Direction>() {{"N", Direction.North}, {"S", Direction.South}, {"E", Direction.East}, {"W", Direction.West}};

        public static Plateau ToPlateau(this string plateauSize)
        {
            var size = plateauSize.Split(' ');
            return new Plateau(new Coordinate(0, 0), new Coordinate(int.Parse(size[0]), int.Parse(size[1])));
        }

        public static Rover ToRover(this string roverInput)
        {
            var roverInputs = roverInput.Split(' ');
            var location = roverInputs[..2].ToList().ToLocation();
            var direction = roverInputs[2].ToDirection();

            return new Rover(location, direction);
        }

        public static Coordinate ToLocation(this List<string> locationInputs)
        {
            return new Coordinate(int.Parse(locationInputs[0]), int.Parse(locationInputs[1]));
        }

        public static Direction ToDirection(this string direction)
        {
            return DirectionsDict[direction];
        }

        public static IEnumerable<Movement> ToMovements(this string movements)
        {
            return movements.Select(movement => MovementsDict[movement.ToString()]);
        }

        public static string ToPosition(this Rover rover)
        {
            return string.Format($"{rover.Location.X} {rover.Location.Y} {DirectionsDict.First(d => d.Value == rover.Direction).Key}");
        }
    }
}