using System.Linq;
using Rover.Domain;

namespace Rover.Test
{
    using System;
    using System.Collections.Generic;
    using Rover.Domain.Models;
    using Xunit;
    public class IntegrationTest
    {
        [Theory]
        [ClassData(typeof(TestData))]
        public void RouterServiceTest((Plateau plateau, List<(RoverRouter roverRouter, Rover expected)> listRoverRouters) testData)
        {
            var routerService = new RouterService(testData.plateau);
            var roverRouters = testData.listRoverRouters.Select(t => t.roverRouter).ToList();
            var roverResults = routerService.Route(roverRouters).ToList();
            var expectedResults = testData.listRoverRouters.Select(t => t.expected).ToList();

            Assert.Equal(expectedResults.ElementAt(0).Direction, roverResults.ElementAt(0).Direction);
            Assert.Equal(expectedResults.ElementAt(0).Location.X, roverResults.ElementAt(0).Location.X);
            Assert.Equal(expectedResults.ElementAt(0).Location.Y, roverResults.ElementAt(0).Location.Y);

            Assert.Equal(expectedResults.ElementAt(1).Direction, roverResults.ElementAt(1).Direction);
            Assert.Equal(expectedResults.ElementAt(1).Location.X, roverResults.ElementAt(1).Location.X);
            Assert.Equal(expectedResults.ElementAt(1).Location.Y, roverResults.ElementAt(1).Location.Y);

            Assert.Equal(expectedResults.ElementAt(2).Direction, roverResults.ElementAt(2).Direction);
            Assert.Equal(expectedResults.ElementAt(2).Location.X, roverResults.ElementAt(2).Location.X);
            Assert.Equal(expectedResults.ElementAt(2).Location.Y, roverResults.ElementAt(2).Location.Y);

            Assert.Equal(expectedResults.ElementAt(3).Direction, roverResults.ElementAt(3).Direction);
            Assert.Equal(expectedResults.ElementAt(3).Location.X, roverResults.ElementAt(3).Location.X);
            Assert.Equal(expectedResults.ElementAt(3).Location.Y, roverResults.ElementAt(3).Location.Y);
        }
    }

    public class TestData : TheoryData<(Plateau, List<(RoverRouter roverRouter, Rover expected)>)>
    {
        public TestData()
        {
            this.Add((new Plateau(new Coordinate(0, 0), new Coordinate(5, 5)), new List<(RoverRouter roverRouter, Rover expected)>()
            {
                (new RoverRouter(new Rover(new Coordinate(1, 2), Direction.North), new List<Movement>()
                {
                    Movement.TurnLeft, Movement.MoveForward, Movement.TurnLeft, Movement.MoveForward, Movement.TurnLeft,
                    Movement.MoveForward, Movement.TurnLeft, Movement.MoveForward, Movement.MoveForward
                }), new Rover(new Coordinate(1, 3), Direction.North)),
                (new RoverRouter(new Rover(new Coordinate(3, 3), Direction.East), new List<Movement>()
                {
                    Movement.MoveForward, Movement.MoveForward, Movement.TurnRight, Movement.MoveForward,
                    Movement.MoveForward, Movement.TurnRight, Movement.MoveForward, Movement.TurnRight,
                    Movement.TurnRight, Movement.MoveForward
                }), new Rover(new Coordinate(5, 1), Direction.East)),
                (new RoverRouter(new Rover(new Coordinate(0, 0), Direction.West), new List<Movement>()
                {
                    Movement.MoveForward, Movement.TurnLeft, Movement.MoveForward
                }), new Rover(new Coordinate(0, 0), Direction.South)),
                (new RoverRouter(new Rover(new Coordinate(5, 5), Direction.North), new List<Movement>()
                {
                    Movement.MoveForward, Movement.TurnRight, Movement.MoveForward
                }), new Rover(new Coordinate(5, 5), Direction.East))
            }));
        }
    }
}