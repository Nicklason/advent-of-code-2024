namespace AdventOfCode;

public class Day06 : BaseDay
{
    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
    }

    private readonly string _input;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static (int, int) Dimensions(string input)
    {
        var width = input.IndexOf(Environment.NewLine);
        var height = (input.Length) / (width);
        return (width, height);
    }

    public static (int, int) IndexToPosition(int index, (int, int) dimensions)
    {
        var y = (index + 1) / (dimensions.Item2 + 1);
        var x = index % (y * (dimensions.Item1 + 1));
        return (x, y);
    }

    public static int PositionToIndex((int, int) position, (int, int) dimensions)
    {
        return position.Item1 + position.Item2 * (dimensions.Item1 + 1);
    }

    public static (int, int) NextPosition(Direction direction, (int, int) position)
    {
        var nextX = position.Item1;
        var nextY = position.Item2;

        switch (direction)
        {
            case Direction.Up:
                nextY--;
                break;
            case Direction.Right:
                nextX++;
                break;
            case Direction.Down:
                nextY++;
                break;
            case Direction.Left:
                nextX--;
                break;
        }

        return (nextX, nextY);
    }

    public static bool Outside((int, int) position, (int, int) dimensions)
    {
        var maxX = dimensions.Item1 - 1;
        var minX = 0;
        var maxY = dimensions.Item2 - 1;
        var minY = 0;

        var (x, y) = position;

        return !(maxX >= x && x >= minX && maxY >= y && y >= minY);
    }

    public static int Solve_1(string input)
    {
        var dimensions = Dimensions(input);
        var position = IndexToPosition(input.IndexOf("^"), dimensions);

        var direction = Direction.Up;

        var visited = new HashSet<(int, int)>();

        while (!Outside(position, dimensions))
        {
            visited.Add(position);

            var nextPosition = NextPosition(direction, position);
            if (Outside(nextPosition, dimensions))
            {
                break;
            }

            var isObstacle = input[PositionToIndex(nextPosition, dimensions)] == '#';
            if (isObstacle)
            {
                direction = (Direction)((1 + ((int)direction)) % 4);
                nextPosition = NextPosition(direction, position);
            }

            position = nextPosition;
        }

        return visited.Count();
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Day06.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day06.Solve_2(_input).ToString());
}
