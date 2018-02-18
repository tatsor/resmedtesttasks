using System;

namespace MarsRoverTestTask
{
    public enum Orientations { N = 1, E = 2, S = 3, W = 4 };
    public class Rover
    {
        public Position RoverPosition { get; set; }
        public Orientations RoverOrientation { get; set; }
        public Plateau RoverPlateau { get; set; }

        public Rover(Position roverPosition, Orientations roverOrientation, Plateau roverPlateau)
        {
            RoverPosition = roverPosition;
            RoverOrientation = roverOrientation;
            RoverPlateau = roverPlateau;
        }

        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        TurnLeft();
                        break;
                    case ('R'):
                        TurnRight();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        public bool IsRoverInsideBoundaries()
        {
           return (RoverPosition.X > RoverPlateau.X || RoverPosition.Y > RoverPlateau.Y)? false: true;
                  
        }

        private void TurnLeft()
        {
            RoverOrientation = (RoverOrientation - 1) < Orientations.N ? Orientations.W : RoverOrientation - 1;
        }

        private void TurnRight()
        {
            RoverOrientation = (RoverOrientation + 1) > Orientations.W ? Orientations.N : RoverOrientation + 1;
        }

        private void Move()
        {
            if (RoverOrientation == Orientations.N)
            {
                RoverPosition.Y++;
            }
            else if (RoverOrientation == Orientations.E)
            {
                RoverPosition.X++;
            }
            else if (RoverOrientation == Orientations.S)
            {
                RoverPosition.Y--;
            }
            else if (RoverOrientation == Orientations.W)
            {
                RoverPosition.X--;
            }
            if (!IsRoverInsideBoundaries())
            {
                throw new ArgumentException("Rover left the plateau.");
            }
        }
    }
}
