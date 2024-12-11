namespace AdventOfCode.Tests;

public class Day10
{
    private readonly string _input =
        @"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day10.Solve_1(_input);

        Assert.Equal(36, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day10.Solve_2(_input);

        Assert.Equal(0, result);
    }
}
