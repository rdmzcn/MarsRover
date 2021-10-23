namespace Rover.Domain.Models
{
    public class Rover
    {
        public Rover(Coordinate location, Direction direction)
        {
            Location = location;
            Direction = direction;
        }

        public Coordinate Location { get; private set; }

        public Direction Direction { get; private set; }

        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.MoveForward:
                    this.MoveForward();
                    break;
                case Movement.TurnLeft:
                    this.TurnLeft();
                    break;
                case Movement.TurnRight:
                    this.TurnRight();
                    break;
            }
        }

        public Coordinate GetNextLocation(Movement movement)
        {
            if (movement == Movement.MoveForward)
            {
                switch (this.Direction)
                {
                    case Direction.North:
                        return new Coordinate(this.Location.X, this.Location.Y + 1);
                    case Direction.South:
                        return new Coordinate(this.Location.X, this.Location.Y - 1);
                    case Direction.East:
                        return new Coordinate(this.Location.X + 1, this.Location.Y);
                    case Direction.West:
                        return new Coordinate(this.Location.X - 1, this.Location.Y);
                }
            }

            return new Coordinate(this.Location.X, this.Location.Y);
        }

        private void MoveForward()
        {
            switch (this.Direction)
            {
                case Direction.North:
                    this.Location.Y += 1;
                    break;
                case Direction.South:
                    this.Location.Y -= 1;
                    break;
                case Direction.East:
                    this.Location.X += 1;
                    break;
                case Direction.West:
                    this.Location.X -= 1;
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.North:
                    this.Direction = Direction.West;
                    break;
                case Direction.South:
                    this.Direction = Direction.East;
                    break;
                case Direction.East:
                    this.Direction = Direction.North;
                    break;
                case Direction.West:
                    this.Direction = Direction.South;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.North:
                    this.Direction = Direction.East;
                    break;
                case Direction.South:
                    this.Direction = Direction.West;
                    break;
                case Direction.East:
                    this.Direction = Direction.South;
                    break;
                case Direction.West:
                    this.Direction = Direction.North;
                    break;
            }
        }
    }
}