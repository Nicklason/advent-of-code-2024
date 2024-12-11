namespace AdventOfCode.Tests;

public class Day11
{
    private readonly string _input = @"125 17";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day11.Solve_1(_input);

        Assert.Equal(55312, result);
    }
}
