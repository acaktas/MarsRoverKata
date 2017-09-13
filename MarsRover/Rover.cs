using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        private readonly Grid _grid;
        private readonly Rotation _rotation = new Rotation();
        private Coordinate _coordinate = new Coordinate(0, 0);

        public Rover(Grid grid)
        {
            _grid = grid;
        }

        public string ExecuteCommand(string command)
        {
            bool isObstacle = false;
            foreach (var character in command)
            {
                switch (character)
                {
                    case 'R':
                        _rotation.RotateRight();
                        break;
                    case 'L':
                        _rotation.RotateLeft();
                        break;
                    case 'F':
                        _coordinate = _grid.NextCoordinateFor(_coordinate, _rotation.Direction.ToString(), out isObstacle);
                        break;
                    case 'B':
                        _coordinate = _grid.PreviousCoordinateFor(_coordinate, _rotation.Direction.ToString(), out isObstacle);
                        break;
                }
            }
            var obstacleString = isObstacle ? "O:" : "";
            return obstacleString + _coordinate.X + ":" + _coordinate.Y + ":" + _rotation.Direction;
        }
    }
}
