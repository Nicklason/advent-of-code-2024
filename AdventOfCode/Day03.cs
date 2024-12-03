namespace AdventOfCode;

using System.Text.RegularExpressions;

public class Day03 : BaseDay
{
    private readonly string _input;

    private static readonly Regex _part1 = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    private static readonly Regex _part2 = new Regex(
        @"don't\(\).*?($|do\(\))",
        RegexOptions.Singleline
    );

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static int Solve_1(string input)
    {
        return _part1.Matches(input).Sum(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
    }

    public static int Solve_2(string input)
    {
        return Solve_1(_part2.Replace(input, ""));
    }

    public override ValueTask<string> Solve_1() => new(Day03.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day03.Solve_2(_input).ToString());
}
