namespace AdventOfCode.Tests;

using System.Numerics;

public class Day14
{
    private readonly string _input =
        @"p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3";

    [Fact]
    public void Simulate()
    {
        var position = new Complex(2, 4);
        var velocity = new Complex(2, -3);

        var robot = (position, velocity);

        var result = AdventOfCode.Day14.Simulate(robot, (11, 7), 5);

        Assert.Equal(new Complex(1, 3), result.Position);
    }

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day14.Solve_1(_input, (11, 7));

        Assert.Equal(12, result);
    }
}
