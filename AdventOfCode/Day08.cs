namespace AdventOfCode;

using System.Numerics;

public class Day08 : BaseDay
{
    private readonly string _input;

    private static Complex Up = Complex.ImaginaryOne;

    public Day08()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static (
        Dictionary<Complex, char> map,
        Dictionary<char, List<Complex>> frequencies
    ) Parse(string input)
    {
        var lines = input.Split(
            Environment.NewLine,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
        );

        var map = (
            from y in Enumerable.Range(0, lines.Length)
            from x in Enumerable.Range(0, lines[0].Length)
            select new KeyValuePair<Complex, char>(-Up * y + x, lines[y][x])
        ).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var frequencies = map.Where(kvp => kvp.Value != '#' && kvp.Value != '.')
            .GroupBy(kvp => kvp.Value)
            .ToDictionary(g => g.Key, g => g.Select(kvp => kvp.Key).ToList());

        return (map, frequencies);
    }

    public static int Solve_1(string input)
    {
        var (map, frequencies) = Parse(input);

        var antinodes = new HashSet<Complex>();

        foreach (var (frequency, positions) in frequencies)
        {
            for (var i = 0; i < positions.Count(); i++)
            {
                for (var j = i + 1; j < positions.Count(); j++)
                {
                    Complex antenna1 = positions[i];
                    Complex antenna2 = positions[j];

                    var difference = antenna1 - antenna2;

                    var antinode1 = antenna1 + difference;
                    if (map.ContainsKey(antinode1))
                    {
                        antinodes.Add(antinode1);
                    }

                    var antinode2 = antenna2 - difference;
                    if (map.ContainsKey(antinode2))
                    {
                        antinodes.Add(antinode2);
                    }
                }
            }
        }

        return antinodes.Count();
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
