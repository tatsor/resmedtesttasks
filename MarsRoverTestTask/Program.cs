using System;
using System.Collections.Generic;

namespace MarsRoverTestTask
{
    class Program
    {
        /// <summary>
        /// Program expects multiple line input followed by an empty line at the end to indicate the end of the input
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int x;
            int y;

            List<string> allInputs = new List<string>();
            Console.WriteLine("Please enter test input followed by an empty line");
            while (true)
            {
                var line = Console.ReadLine();
                if(string.IsNullOrEmpty(line))
                {
                    break;
                }
                allInputs.Add(line);
            }
            if (allInputs.Count == 0)
            {
                Console.WriteLine("Input is empty. Please click enter and start again.");
                Console.ReadLine();
            }
            var size = allInputs[0].Split(' ');
            if(size.Length != 2)
            {
                Console.WriteLine("Plateau size input expected 2 values separatd by spaces. Please click enter and start again.");
                Console.ReadLine();
                return;
            }
            if(!(int.TryParse(size[0], out x) && int.TryParse(size[1], out y)))
            {
                Console.WriteLine("Plateau size input expected 2 integer values. Please click enter and start again.");
                Console.ReadLine();
                return;
            }
            var plateau = new Plateau(x, y);

            int i = 1;
            while (i < allInputs.Count)
            {
                var input = allInputs[i];
                i++;
                var position = input.Split(' ');
                if (position.Length != 3)
                {
                    Console.WriteLine("Unexpected number of arguments. Rover position input expected 3 values separated by spaces. Please click enter and start again.");
                    Console.ReadLine();
                    return;
                }
                if (!(int.TryParse(position[0], out x) && int.TryParse(position[1], out y)))
                {
                    Console.WriteLine("Rover position coordinates expected 2 integer values. Please click enter and start again.");
                    Console.ReadLine();
                    return;
                }

                var orientation = (Orientations)Enum.Parse(typeof(Orientations), position[2]);
                var roverPosition = new Position(x, y);
                var rover = new Rover(roverPosition, orientation, plateau);

                input = allInputs[i];
               
                i++;
                try
                {
                    rover.Process(input);
                    Console.WriteLine(rover.RoverPosition.X + " " +
                        rover.RoverPosition.Y + " " + rover.RoverOrientation.ToString());
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message + " Please click enter and start again.");
                    Console.ReadLine();
                    return;
                }
            }
            Console.ReadLine();
        }
    }
}
