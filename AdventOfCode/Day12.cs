namespace AdventOfCode;

using System.Numerics;

public class Day12 : BaseDay
{
    private readonly string _input;

    private static readonly Complex Up = -Complex.ImaginaryOne;
    private static readonly Complex Down = Complex.ImaginaryOne;
    private static readonly Complex Right = 1;
    private static readonly Complex Left = -1;

    private static readonly Complex[] Directions = new[] { Up, Down, Left, Right };
    private static readonly (Complex, Complex)[] Corners = new[]
    {
        (Up, Right),
        (Up, Left),
        (Down, Right),
        (Down, Left),
    };

    public Day12()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static IDictionary<Complex, char> Parse(string input)
    {
        var lines = input.Split(
            Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
        );

        return (
            from y in Enumerable.Range(0, lines.Length)
            from x in Enumerable.Range(0, lines[0].Length)
            select new KeyValuePair<Complex, char>(Down * y + x, lines[y][x])
        ).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static ISet<Complex> DiscoverRegion(Complex start, IDictionary<Complex, char> map)
    {
        var visited = new Dictionary<Complex, bool>();

        var queue = new Queue<Complex>();
        queue.Enqueue(start);

        var character = map[start];

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.ContainsKey(current))
            {
                continue;
            }

            var match = map[current] == character;

            visited.TryAdd(current, match);

            if (!match)
            {
                continue;
            }

            foreach (var direction in Directions)
            {
                var next = current + direction;
                if (map.ContainsKey(next))
                {
                    queue.Enqueue(next);
                }
            }
        }

        var region = visited.Where(seen => seen.Value).Select(seen => seen.Key).ToHashSet();

        return region;
    }

    public static int Perimiter(Complex position, ISet<Complex> region)
    {
        var perimiter = 0;

        foreach (var direction in Directions)
        {
            if (!region.Contains(position + direction))
            {
                perimiter++;
            }
        }

        return perimiter;
    }

    public static int FindPrice(string input, Func<Complex, ISet<Complex>, int> counter)
    {
        var map = Parse(input);

        var remaining = new HashSet<Complex>(map.Keys);

        var total = 0;

        while (remaining.Count > 0)
        {
            var region = DiscoverRegion(remaining.First(), map);

            foreach (var location in region)
            {
                total += region.Count * counter(location, region);
                remaining.Remove(location);
            }
        }

        return total;
    }

    public static int Solve_1(string input)
    {
        return FindPrice(input, Perimiter);
    }

    public static int Sides(Complex position, ISet<Complex> region)
    {
        var sides = 0;

        foreach (var (ud, rl) in Corners)
        {
            if (!region.Contains(position + ud) && !region.Contains(position + rl))
            {
                sides++;
            }
            else if (
                region.Contains(position + ud)
                && region.Contains(position + rl)
                && !region.Contains(position + ud + rl)
            )
            {
                sides++;
            }
        }

        return sides;
    }

    public static int Solve_2(string input)
    {
        return FindPrice(input, Sides);
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
