using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;
        private readonly List<Coordinate> _obstacles;

        public Grid(int height, int width, List<Coordinate> obstacles)
        {
            _maxHeight = height;
            _maxWidth = width;
            _obstacles = obstacles;
        }
        public Coordinate NextCoordinateFor(Coordinate coordinate, string direction, out bool isObstacle)
        {
            isObstacle = false;
            var x = coordinate.X;
            var y = coordinate.Y;

            if (direction == "N")
            {
                y = (y + 1) % _maxHeight;
            }
            if (direction == "E")
            {
                x = (x + 1) % _maxWidth;
            }
            if (direction == "W")
            {
                x = (x > 0) ? x - 1 : _maxWidth - 1;
            }
            if (direction == "S")
            {
                y = (y > 0) ? y - 1 : _maxHeight - 1;
            }

            var newCoordinate = new Coordinate(x, y);
            if (!_obstacles.Contains(newCoordinate)) return newCoordinate;
            isObstacle = true;
            return coordinate;
        }
        public Coordinate PreviousCoordinateFor(Coordinate coordinate, string direction, out bool isObstacle)
        {
            isObstacle = false;
            var x = coordinate.X;
            var y = coordinate.Y;

            if (direction == "N")
            {
                y = (y > 0) ? y - 1 : _maxHeight - 1;
            }
            if (direction == "E")
            {
                x = (x > 0) ? x - 1 : _maxWidth - 1;
            }
            if (direction == "W")
            {
                x = (x + 1) % _maxWidth;
            }
            if (direction == "S")
            {
                y = (y + 1) % _maxHeight;
            }

            var newCoordinate = new Coordinate(x, y);
            if (!_obstacles.Contains(newCoordinate)) return newCoordinate;
            isObstacle = true;
            return coordinate;
        }
    }
}
