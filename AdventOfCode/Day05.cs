namespace AdventOfCode;

public class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static (Dictionary<int, List<int>>, List<int[]>) ParseInput(string input)
    {
        var lines = input.Trim().Split("\n", StringSplitOptions.TrimEntries);

        var rules = new Dictionary<int, List<int>>();

        var i = 0;

        for (; i < lines.Length; i++)
        {
            var line = lines[i];
            if (line == "")
            {
                break;
            }

            var parts = line.Split("|");

            var first = int.Parse(parts[0]);
            var second = int.Parse(parts[1]);

            if (rules.ContainsKey(second))
            {
                rules[second].Add(first);
            }
            else
            {
                rules.Add(second, new List<int> { first });
            }
        }

        var updates = new List<int[]>();

        for (i++; i < lines.Length; i++)
        {
            var line = lines[i];

            var pages = line.Split(",").Select(int.Parse).ToArray();
            updates.Add(pages);
        }

        return (rules, updates);
    }

    public static int Solve_1(string input)
    {
        var (rules, updates) = ParseInput(input);

        var sum = 0;

        foreach (var update in updates)
        {
            var test = new HashSet<int>();

            var good = true;

            foreach (var page in update)
            {
                if (test.Contains(page))
                {
                    good = false;
                    break;
                }

                foreach (var rule in rules.GetValueOrDefault(page, new List<int>()))
                {
                    test.Add(rule);
                }
            }

            if (good)
            {
                sum += update[update.Length / 2];
            }
        }

        return sum;
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Day05.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day05.Solve_2(_input).ToString());
}
