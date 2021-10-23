using System;
using System.Collections.Generic;
using Rover.Domain;
using Rover.Domain.Extensions;
using Rover.Domain.Models;

namespace Rover.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from Mars");
            Run();
        }

        private static void Run()
        {
            Console.WriteLine("Please entered plateau size(width height)");
            var plateauSize = Console.ReadLine();
            var plateau = plateauSize.ToPlateau();

            var routerService = new RouterService(plateau);
            var roverRouters = new List<RoverRouter>();

            while (true)
            {
                Console.WriteLine("Please entered rover position or leave it blank to finish");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                var rover = input.ToRover();

                Console.WriteLine("Please entered map");
                var movementsStr = Console.ReadLine();
                var movements = movementsStr.ToMovements();

                roverRouters.Add(new RoverRouter(rover, movements));
            }

            var roverResults = routerService.Route(roverRouters);

            Console.WriteLine("Rover result:");
            foreach (var roverResult in roverResults)
            {
                Console.WriteLine(roverResult.ToPosition());
            }
        }
    }
}
