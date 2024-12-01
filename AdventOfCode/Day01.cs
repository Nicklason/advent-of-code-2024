namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static List<(int, int)> ParseInput(string input)
    {
        return input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            .Where(parts => parts.Length == 2)
            .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])))
            .ToList();
    }

    public static int Solve_1(string input)
    {
        var numbers = ParseInput(input);

        var left = new List<int>();
        var right = new List<int>();

        foreach (var (num1, num2) in numbers)
        {
            left.Add(num1);
            right.Add(num2);
        }

        left.Sort();
        right.Sort();

        int difference = 0;

        for (var i = 0; i < numbers.Count; i++)
        {
            difference += Math.Abs(right[i] - left[i]);
        }

        return difference;
    }

    public static int Solve_2(string input)
    {
        var numbers = ParseInput(input);

        var left = new List<int>();
        var right = new Dictionary<int, int>();

        foreach (var (num1, num2) in numbers)
        {
            left.Add(num1);
            right[num2] = right.GetValueOrDefault(num2, 0) + 1;
        }
        int similarity = 0;

        foreach (var num1 in left)
        {
            var count2 = right.GetValueOrDefault(num1, 0);
            similarity += num1 * count2;
        }

        return similarity;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
