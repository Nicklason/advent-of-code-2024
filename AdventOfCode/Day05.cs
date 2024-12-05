namespace AdventOfCode;

public class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static (Dictionary<int, List<int>>, List<List<int>>) ParseInput(string input)
    {
        var lines = input.Trim().Split("\n", StringSplitOptions.TrimEntries);
        var blankIndex = Array.IndexOf(lines, "");

        var rules = lines
            .Take(blankIndex)
            .Select(line => line.Split("|").Select(int.Parse).ToArray())
            .GroupBy(parts => parts[1], parts => parts[0])
            .ToDictionary(group => group.Key, group => group.ToList());

        var updates = lines
            .Skip(blankIndex + 1)
            .Select(line => line.Split(",").Select(int.Parse).ToList())
            .ToList();

        return (rules, updates);
    }

    public static bool IsValid(Dictionary<int, List<int>> rules, List<int> update)
    {
        var test = new HashSet<int>();

        foreach (var page in update)
        {
            if (test.Contains(page))
            {
                return false;
            }
            test.UnionWith(rules.GetValueOrDefault(page, new List<int>()));
        }

        return true;
    }

    public static int Solve_1(string input)
    {
        var (rules, updates) = ParseInput(input);

        return updates
            .Where(update => IsValid(rules, update))
            .Select((update => update[update.Count / 2]))
            .Sum();
    }

    public static int Solve_2(string input)
    {
        var (rules, updates) = ParseInput(input);

        return updates
            .Where(update => !IsValid(rules, update))
            .Select(update =>
            {
                update.Sort((a, b) => rules.ContainsKey(a) && rules[a].Contains(b) ? 1 : -1);
                return update[update.Count / 2];
            })
            .Sum();
    }

    public override ValueTask<string> Solve_1() => new(Day05.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day05.Solve_2(_input).ToString());
}
