namespace AdventOfCode;

using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using Dimensions = (int Width, int Height);
using Robot = (System.Numerics.Complex Position, System.Numerics.Complex Velocity);

public class Day14 : BaseDay
{
    private readonly string _input;

    private static readonly Regex _regex = new(@"(-?\d*),(-?\d*)");

    private static readonly Complex Down = Complex.ImaginaryOne;

    public Day14()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static IEnumerable<Robot> Parse(string input)
    {
        return _regex
            .Matches(input)
            .Select(match =>
                int.Parse(match.Groups[2].Value) * Down + int.Parse(match.Groups[1].Value)
            )
            .Chunk(2)
            .Select(chunk => (Position: chunk[0], Velocity: chunk[1]));
    }

    public static double Modulo(double value, double modulus) =>
        (value % modulus + modulus) % modulus;

    public static Robot Simulate(Robot robot, (int Width, int Height) dimensions, int seconds)
    {
        var position = robot.Position + (robot.Velocity * seconds);

        robot.Position = new Complex(
            Modulo(position.Real, dimensions.Width),
            Modulo(position.Imaginary, dimensions.Height)
        );

        return robot;
    }

    public static int SafetyFactor(IEnumerable<Robot> robots, Dimensions dimensions)
    {
        var midpointX = dimensions.Width / 2;
        var midpointY = dimensions.Height / 2;

        var groups = robots
            .Where(robot =>
                robot.Position.Real != midpointX && robot.Position.Imaginary != midpointY
            )
            .GroupBy(robot =>
                (robot.Position.Real > midpointX ? 1 : 0)
                + (robot.Position.Imaginary > midpointY ? 2 : 0)
            );

        return groups.Aggregate(1, (cur, acc) => cur * acc.Count());
    }

    public static int Solve_1(string input, Dimensions dimensions)
    {
        var robots = Parse(input);

        var simulated = robots.Select(robot => Simulate(robot, dimensions, 100));

        return SafetyFactor(simulated, dimensions);
    }

    public static string Plot(IEnumerable<Robot> robots, Dimensions dimensions)
    {
        var grid = new char[dimensions.Height, dimensions.Width];
        foreach (var robot in robots)
        {
            grid[(int)robot.Position.Imaginary, (int)robot.Position.Real] = '#';
        }
        var builder = new StringBuilder();
        for (var y = 0; y < dimensions.Height; y++)
        {
            for (var x = 0; x < dimensions.Width; x++)
            {
                builder.Append(grid[y, x] == '#' ? "#" : ".");
            }
            builder.AppendLine();
        }
        return builder.ToString();
    }

    public static int Solve_2(string input, Dimensions dimensions)
    {
        var robots = Parse(input).ToArray();

        var seconds = 0;

        while (true)
        {
            seconds++;
            var simulated = robots.Select(robot => Simulate(robot, dimensions, seconds));
            var plot = Plot(simulated, dimensions);
            if (plot.Contains("#################"))
            {
                return seconds;
            }
        }
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input, (101, 103)).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input, (101, 103)).ToString());
}
