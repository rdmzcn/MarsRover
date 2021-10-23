using Rover.Domain.Models;
using Xunit;

namespace Rover.Test
{
    public class UnitTests
    {
        [Theory]
        [InlineData(2, 2, Direction.North, 2, 3)]
        [InlineData(2, 2, Direction.South, 2, 1)]
        [InlineData(2, 2, Direction.East, 3, 2)]
        [InlineData(2, 2, Direction.West, 1, 2)]
        public void MoveForwardTest(int x, int y, Direction direction, int expectedX, int expectedY)
        {
            var rover = new Domain.Models.Rover(new Coordinate(x, y), direction);
            rover.Move(Movement.MoveForward);

            Assert.Equal(expectedX, rover.Location.X);
            Assert.Equal(expectedY, rover.Location.Y);
        }

        [Theory]
        [InlineData(Direction.North, Movement.TurnLeft, Direction.West)]
        [InlineData(Direction.North, Movement.TurnRight, Direction.East)]
        [InlineData(Direction.South, Movement.TurnLeft, Direction.East)]
        [InlineData(Direction.South, Movement.TurnRight, Direction.West)]
        [InlineData(Direction.East, Movement.TurnLeft, Direction.North)]
        [InlineData(Direction.East, Movement.TurnRight, Direction.South)]
        [InlineData(Direction.West, Movement.TurnLeft, Direction.South)]
        [InlineData(Direction.West, Movement.TurnRight, Direction.North)]
        public void TurnTest(Direction direction, Movement movement, Direction expectedDirection)
        {
            var rover = new Domain.Models.Rover(new Coordinate(0, 0), direction);
            rover.Move(movement);

            Assert.Equal(expectedDirection, rover.Direction);
        }
    }
}
