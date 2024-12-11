namespace AdventOfCode;

public class Day11 : BaseDay
{
    private readonly string _input;

    public Day11()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static Dictionary<long, long> Parse(string input)
    {
        return input
            .Split(' ')
            .Select(long.Parse)
            .GroupBy(stone => stone)
            .ToDictionary(stone => stone.Key, stones => (long)stones.Count());
    }

    public static Dictionary<long, long> Simulate(Dictionary<long, long> stones)
    {
        var result = new Dictionary<long, long>();

        foreach (var (current, count) in stones)
        {
            long left = -1;
            long right = -1;

            if (current == 0)
            {
                left = 1;
            }
            else
            {
                var digits = Math.Floor(Math.Log10(current) + 1);
                if (digits % 2 == 0)
                {
                    var temp = current / (Math.Pow(10, digits / 2));
                    left = (long)Math.Floor(temp);
                    var remainder = temp - left;
                    right = (long)Math.Round(remainder * Math.Pow(10, digits / 2));
                }
                else
                {
                    left = current * 2024;
                }
            }

            result[left] = result.GetValueOrDefault(left, 0L) + count;
            if (right != -1)
            {
                result[right] = result.GetValueOrDefault(right, 0L) + count;
            }
        }

        return result;
    }

    public static long Solve_1(string input)
    {
        var stones = Parse(input);

        for (var i = 0; i < 25; i++)
        {
            stones = Simulate(stones);
        }

        return stones.Sum(stone => stone.Value);
    }

    public static long Solve_2(string input)
    {
        var stones = Parse(input);

        for (var i = 0; i < 75; i++)
        {
            stones = Simulate(stones);
        }

        return stones.Sum(stone => stone.Value);
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
