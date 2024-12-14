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

    public static (int A, int B)? Solve(ClawMachine machine)
    {
        var determinant = machine.A.X * machine.B.Y - machine.A.Y * machine.B.X;
        if (determinant == 0)
        {
            return null;
        }

        int determinantA =
            machine.Destination.X * machine.B.Y - machine.Destination.Y * machine.B.X;
        int determinantB =
            machine.A.X * machine.Destination.Y - machine.A.Y * machine.Destination.X;

        int a = determinantA / determinant;
        int b = determinantB / determinant;

        if (a < 0 || b < 0 || determinantA % determinant != 0 || determinantB % determinant != 0)
        {
            return null;
        }

        return (a, b);
    }

    public static int Tokens(ClawMachine machine)
    {
        var solved = Solve(machine);

        if (!solved.HasValue)
        {
            return 0;
        }

        return solved.Value.A * 3 + solved.Value.B;
    }

    public static int Solve_1(string input)
    {
        var machines = Parse(input);
        return machines.Sum(Tokens);
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());

    public class ClawMachine
    {
        public readonly (int X, int Y) A;
        public readonly (int X, int Y) B;
        public (int X, int Y) Destination;

        public ClawMachine((int, int) a, (int, int) b, (int, int) destination)
        {
            A = a;
            B = b;
            Destination = destination;
        }
    }
}
