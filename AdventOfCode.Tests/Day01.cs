namespace AdventOfCode.Tests;

public class Day01
{
    private readonly string _input =
        @"
3   4
4   3
2   5
1   3
3   9
3   3";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day01.Solve_1(_input);

        Assert.Equal(11, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day01.Solve_2(_input);

        Assert.Equal(31, result);
    }
}
