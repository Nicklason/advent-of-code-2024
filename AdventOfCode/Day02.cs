namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static List<T> RemoveOneFromList<T>(List<T> list, int index)
    {
        return list.Slice(0, index).Concat(list.Slice(index + 1, list.Count - index - 1)).ToList();
    }

    public static bool IsSafeReport(string report, bool dampener)
    {
        var levels = report
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        if (!dampener)
        {
            return AreSafeLevels(levels);
        }

        for (var i = 0; i < levels.Count; i++)
        {
            var slice = RemoveOneFromList(levels, i);
            if (AreSafeLevels(slice))
            {
                return true;
            }
        }

        return false;
    }

    public static bool AreSafeLevels(List<int> levels)
    {
        int direction = 0;
        for (var i = 1; i < levels.Count; i++)
        {
            var difference = levels[i] - levels[i - 1];
            if (direction == 0)
            {
                if (difference == 0)
                {
                    return false;
                }

                direction = difference > 0 ? 1 : -1;
            }

            if (difference * direction < 0)
            {
                return false;
            }

            int abs = Math.Abs(difference);
            if (abs < 1 || abs > 3)
            {
                return false;
            }
        }

        return true;
    }

    public static int Solve(string input, bool dampener)
    {
        var reports = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        var safe = 0;
        foreach (var report in reports)
        {
            if (IsSafeReport(report, dampener))
            {
                safe++;
            }
        }

        return safe;
    }

    public static int Solve_1(string input)
    {
        return Solve(input, false);
    }

    public static int Solve_2(string input)
    {
        return Solve(input, true);
    }

    public override ValueTask<string> Solve_1() => new(Day02.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day02.Solve_2(_input).ToString());
}
