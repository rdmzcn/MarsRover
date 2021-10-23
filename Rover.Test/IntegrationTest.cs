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

            Assert.Equal(expectedResults.First().Direction, roverResults.First().Direction);
            Assert.Equal(expectedResults.First().Location.X, roverResults.First().Location.X);
            Assert.Equal(expectedResults.First().Location.Y, roverResults.First().Location.Y);

            Assert.Equal(expectedResults.Last().Direction, roverResults.Last().Direction);
            Assert.Equal(expectedResults.Last().Location.X, roverResults.Last().Location.X);
            Assert.Equal(expectedResults.Last().Location.Y, roverResults.Last().Location.Y);
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
                }), new Rover(new Coordinate(5, 1), Direction.East))
            }));
        }
    }
}