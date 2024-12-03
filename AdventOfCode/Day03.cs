namespace AdventOfCode;

using System.Diagnostics;
using System.Text.RegularExpressions;

public class Day03 : BaseDay
{
    private readonly string _input;

    private static readonly Regex _part1 = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    private static readonly Regex _part2Replace = new Regex(
        @"don't\(\).*?($|do\(\))",
        RegexOptions.Singleline
    );
    private static readonly Regex _part2Pattern = new Regex(
        @"(mul\((\d{1,3}),(\d{1,3})\))|(don't\(\))|(do\(\))"
    );

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static int Solve_1(string input)
    {
        return _part1
            .Matches(input)
            .Sum(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value));
    }

    public static int Solve_2(string input)
    {
        var replace = Solve_2_Replace(input);
        var pattern = Solve_2_Pattern(input);

        Debug.Assert(replace == pattern);

        return replace;
    }

    public static int Solve_2_Replace(string input)
    {
        return Solve_1(_part2Replace.Replace(input, " "));
    }

    public static int Solve_2_Pattern(string input)
    {
        var matches = _part2Pattern.Matches(input);

        var (_, result) = matches.Aggregate(
            (true, 0),
            (state, match) =>
            {
                var (enabled, sum) = state;

                return match.Value switch
                {
                    "don't()" => (false, sum),
                    "do()" => (true, sum),
                    _ when enabled => (
                        enabled,
                        sum + (int.Parse(match.Groups[2].Value) * int.Parse(match.Groups[3].Value))
                    ),
                    _ => state,
                };
            }
        );

        return result;
    }

    public override ValueTask<string> Solve_1() => new(Day03.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day03.Solve_2(_input).ToString());
}
