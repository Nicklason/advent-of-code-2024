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

    public static (IEnumerable<(int, int)> visited, bool loop) Path(
        Dictionary<(int, int), char> map,
        (int, int) position
    )
    {
        var direction = Direction.Up;

        var visited = new HashSet<(Direction, (int, int))>();

        while (map.ContainsKey(position) && !visited.Contains((direction, position)))
        {
            visited.Add((direction, position));

            var next = NextPosition(direction, position);
            if (map.GetValueOrDefault(next) == '#')
            {
                direction = (Direction)((1 + ((int)direction)) % 4);
            }
            else
            {
                position = next;
            }
        }

        return (
            visited: visited.Select(p => p.Item2).Distinct(),
            loop: visited.Contains((direction, position))
        );
    }

    public static (Dictionary<(int, int), char>, (int, int)) Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var map = new Dictionary<(int, int), char>();

        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[0].Length; x++)
            {
                map[(x, y)] = lines[y][x];
            }
        }

        var start = map.First(x => x.Value == '^').Key;

        return (map, start);
    }

    public static int Solve_1(string input)
    {
        var (map, start) = Parse(input);
        return Path(map, start).visited.Count();
    }

    public static int Solve_2(string input)
    {
        var (map, start) = Parse(input);

        var positions = Path(map, start).visited;

        var loops = 0;

        foreach (var position in positions)
        {
            if (map.GetValueOrDefault(position) != '.')
            {
                continue;
            }

            map[position] = '#';

            var path = Path(map, start);
            if (path.loop)
            {
                loops++;
            }

            map[position] = '.';
        }

        return loops;
    }

    public override ValueTask<string> Solve_1() => new(Day06.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day06.Solve_2(_input).ToString());
}
