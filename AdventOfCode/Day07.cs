namespace AdventOfCode;

public class Day07 : BaseDay
{
    private readonly string _input;

    public Day07()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static IEnumerable<(long result, List<long> numbers)> Parse(string input)
    {
        return input
            .Replace(":", "")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(l => l.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse))
            .Select(l => (l.First(), l.Skip(1).ToList()));
    }

    public static bool SolveablePartOne((long test, List<long> numbers) equation)
    {
        return Solveable(equation.test, equation.numbers[1..], equation.numbers[0], false);
    }

    public static bool SolveablePartTwo((long test, List<long> numbers) equation)
    {
        return Solveable(equation.test, equation.numbers[1..], equation.numbers[0], true);
    }

    public static bool Solveable(long test, List<long> numbers, long result, bool partTwo)
    {
        if (result > test)
        {
            return false;
        }
        else if (numbers.Count() == 0)
        {
            return result == test;
        }

        var number = numbers[0];
        var next = numbers[1..];

        return Solveable(test, next, result + number, partTwo)
            || Solveable(test, next, result * number, partTwo)
            || partTwo && Solveable(test, next, long.Parse($"{result}{number}"), partTwo);
    }

    public static double Solve_1(string input)
    {
        return Parse(input).Where(SolveablePartOne).Sum((l => l.result));
    }

    public static long Solve_2(string input)
    {
        return Parse(input).Where(SolveablePartTwo).Sum((l => l.result));
    }

    public override ValueTask<string> Solve_1() => new(Day07.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day07.Solve_2(_input).ToString());
}
