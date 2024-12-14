namespace AdventOfCode;

using System.Text.RegularExpressions;

public class Day13 : BaseDay
{
    private readonly string _input;

    private static readonly Regex _regex = new(@"X(\+|=)(\d*), Y(\+|=)(\d*)");

    public Day13()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static IEnumerable<ClawMachine> Parse(string input)
    {
        var list = new List<(int, int)>();

        var matches = _regex.Matches(input);

        var machines = matches
            .Select(match => (int.Parse(match.Groups[2].Value), int.Parse(match.Groups[4].Value)))
            .Chunk(3)
            .Select(chunk => new ClawMachine(chunk[0], chunk[1], chunk[2]));

        return machines;
    }

    public static (long A, long B)? Solve(ClawMachine machine)
    {
        var determinant = machine.A.X * machine.B.Y - machine.A.Y * machine.B.X;
        if (determinant == 0)
        {
            return null;
        }

        long determinantA =
            machine.Destination.X * machine.B.Y - machine.Destination.Y * machine.B.X;
        long determinantB =
            machine.A.X * machine.Destination.Y - machine.A.Y * machine.Destination.X;

        long a = determinantA / determinant;
        long b = determinantB / determinant;

        if (a < 0 || b < 0 || determinantA % determinant != 0 || determinantB % determinant != 0)
        {
            return null;
        }

        return (a, b);
    }

    public static long Tokens(ClawMachine machine)
    {
        var solved = Solve(machine);

        if (!solved.HasValue)
        {
            return 0;
        }

        return solved.Value.A * 3 + solved.Value.B;
    }

    public static long Solve_1(string input)
    {
        var machines = Parse(input);
        return machines.Sum(Tokens);
    }

    public static long Solve_2(string input)
    {
        var machines = Parse(input);
        return machines.Sum(machine =>
        {
            machine.Destination = (
                machine.Destination.X + 10000000000000,
                machine.Destination.Y + 10000000000000
            );
            return Tokens(machine);
        });
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());

    public class ClawMachine
    {
        public readonly (long X, long Y) A;
        public readonly (long X, long Y) B;
        public (long X, long Y) Destination;

        public ClawMachine((long, long) a, (long, long) b, (long, long) destination)
        {
            A = a;
            B = b;
            Destination = destination;
        }
    }
}
