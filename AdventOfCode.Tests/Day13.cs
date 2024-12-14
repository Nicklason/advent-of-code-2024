namespace AdventOfCode.Tests;

public class Day13
{
    private readonly string _input =
        @"Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400

Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=12748, Y=12176

Button A: X+17, Y+86
Button B: X+84, Y+37
Prize: X=7870, Y=6450

Button A: X+69, Y+23
Button B: X+27, Y+71
Prize: X=18641, Y=10279";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day13.Solve_1(_input);

        Assert.Equal(480, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day13.Solve_2(_input);

        Assert.Equal(0, result);
    }
}
