namespace AdventOfCode;

using System.Diagnostics;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static int Solve_1(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        var safe = 0;
        foreach (var line in lines)
        {
            var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var previous = int.Parse(parts[0]);
            int direction = 0;

            for (var i = 1; i < parts.Length; i++)
            {
                var num = int.Parse(parts[i]);

                var difference = num - previous;
                previous = num;
                if (direction == 0)
                {
                    if (difference == 0)
                    {
                        break;
                    }
                    direction = difference > 0 ? 1 : -1;
                }

                Debug.Assert(direction != 0);

                var abs = Math.Abs(difference);
                if (difference * direction < 0)
                {
                    break;
                }

                if (abs < 1 || abs > 3)
                {
                    break;
                }

                if (i == parts.Length - 1)
                {
                    safe++;
                }
            }
        }

        return safe;
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Day02.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new("");
}
