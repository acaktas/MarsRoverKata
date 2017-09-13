namespace MarsRover
{
    public class Rotation
    {
        public DirectionEnum Direction { get; set; }

        public Rotation()
        {
            Direction = DirectionEnum.N;
        }

        public void RotateRight()
        {
            if (Direction == DirectionEnum.N) Direction = DirectionEnum.E;
            else if (Direction == DirectionEnum.E) Direction = DirectionEnum.S;
            else if (Direction == DirectionEnum.S) Direction = DirectionEnum.W;
            else Direction = DirectionEnum.N;
        }

        public void RotateLeft()
        {
            if (Direction == DirectionEnum.N) Direction = DirectionEnum.W;
            else if (Direction == DirectionEnum.W) Direction = DirectionEnum.S;
            else if (Direction == DirectionEnum.S) Direction = DirectionEnum.E;
            else Direction = DirectionEnum.N;
        }
    }

    public enum DirectionEnum
    {
        N,
        E,
        S,
        W
    }
}