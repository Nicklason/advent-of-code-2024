namespace AdventOfCode;

using System.Text.RegularExpressions;

public class Day03 : BaseDay
{
    private readonly string _input;

    private static readonly Regex _part1 = new Regex(@"mul\((\d+),(\d+)\)");

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static int Solve_1(string input)
    {
        var matches = _part1.Matches(input);

        var result = matches
            .Select((match) => (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)))
            .Aggregate(0, (acc, pair) => acc + (pair.Item1 * pair.Item2));

        return result;
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Day03.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day03.Solve_2(_input).ToString());
}
