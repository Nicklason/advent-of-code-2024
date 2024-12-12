namespace AdventOfCode.Tests;

public class Day12
{
    private readonly string _input =
        @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day12.Solve_1(_input);

        Assert.Equal(1930, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day12.Solve_2(_input);

        Assert.Equal(1206, result);
    }
}
