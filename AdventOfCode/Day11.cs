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

    public static (long Left, long Right) Change(long stone)
    {
        if (stone == 0)
        {
            return (1, -1);
        }

        var digits = Math.Floor(Math.Log10(stone) + 1);
        if (digits % 2 == 0)
        {
            var temp = stone / (Math.Pow(10, digits / 2));
            var left = (long)Math.Floor(temp);
            var remainder = temp - left;
            var right = (long)Math.Round(remainder * Math.Pow(10, digits / 2));

            return (left, right);
        }

        return (stone * 2024, -1);
    }

    public static Dictionary<long, long> Blink(Dictionary<long, long> stones)
    {
        var result = new Dictionary<long, long>();

        foreach (var (label, count) in stones)
        {
            var (left, right) = Change(label);

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
            stones = Blink(stones);
        }

        return stones.Sum(stone => stone.Value);
    }

    public static long Solve_2(string input)
    {
        var stones = Parse(input);

        for (var i = 0; i < 75; i++)
        {
            stones = Blink(stones);
        }

        return stones.Sum(stone => stone.Value);
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
