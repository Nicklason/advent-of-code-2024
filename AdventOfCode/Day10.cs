namespace AdventOfCode;

using System.Numerics;

public class Day10 : BaseDay
{
    private readonly string _input;

    private static readonly Complex Down = Complex.ImaginaryOne;

    public Day10()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static (Dictionary<Complex, int> map, List<Complex> lowest) Parse(string input)
    {
        var lines = input.Split(
            Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
        );

        var map = (
            from y in Enumerable.Range(0, lines.Length)
            from x in Enumerable.Range(0, lines[0].Length)
            select new KeyValuePair<Complex, int>(Down * y + x, lines[y][x] - '0')
        ).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var lowest = map.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key).ToList();

        return (map, lowest);
    }

    public static void DiscoverTrail(
        Complex position,
        Dictionary<Complex, int> map,
        int steps,
        HashSet<Complex> ends
    )
    {
        if (!map.ContainsKey(position))
        {
            return;
        }

        var height = map[position];
        if (height != steps)
        {
            return;
        }

        if (steps >= 9)
        {
            if (height == 9)
            {
                ends.Add(position);
            }
            return;
        }

        DiscoverTrail(position + Down, map, steps + 1, ends);
        DiscoverTrail(position - Down, map, steps + 1, ends);
        DiscoverTrail(position + 1, map, steps + 1, ends);
        DiscoverTrail(position - 1, map, steps + 1, ends);
    }

    public static int Solve_1(string input)
    {
        var (map, lowest) = Parse(input);

        return lowest.Sum(position =>
        {
            var heads = new HashSet<Complex>();
            DiscoverTrail(position, map, 0, heads);
            return heads.Count;
        });
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
