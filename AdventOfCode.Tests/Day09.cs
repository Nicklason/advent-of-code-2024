namespace AdventOfCode.Tests;

public class Day09
{
    private readonly string _input = @"2333133121414131402";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day09.Solve_1(_input);

        Assert.Equal(1928, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day09.Solve_2(_input);

        Assert.Equal(0, result);
    }
}
