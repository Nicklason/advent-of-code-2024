namespace AdventOfCode;

public class Day11 : BaseDay
{
    private readonly string _input;

    public Day11()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static LinkedList<long> Parse(string input)
    {
        return new LinkedList<long>(input.Split(' ').Select(long.Parse));
    }

    public static void Simulate(LinkedList<long> stones)
    {
        var next = stones.First;

        while (next != null)
        {
            var current = next;
            if (current.Value == 0)
            {
                current.Value = 1;
            }
            else
            {
                var digits = Math.Floor(Math.Log10(current.Value) + 1);
                if (digits % 2 == 0)
                {
                    var value = current.Value;
                    var temp = value / (Math.Pow(10, digits / 2));
                    var left = Math.Floor(temp);
                    var remainder = temp - left;
                    var right = Math.Round(remainder * Math.Pow(10, digits / 2));

                    current.Value = (long)left;
                    current = new LinkedListNode<long>((long)right);

                    stones.AddAfter(next, current);
                }
                else
                {
                    current.Value *= 2024;
                }
            }

            next = current.Next;
        }
    }

    public static int Solve_1(string input)
    {
        var list = Parse(input);

        for (var i = 0; i < 25; i++)
        {
            Simulate(list);
        }

        return list.Count();
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
