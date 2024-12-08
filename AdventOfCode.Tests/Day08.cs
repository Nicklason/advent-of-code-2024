namespace AdventOfCode.Tests;

public class Day08
{
    private readonly string _input =
        @"......#....#
...#....0...
....#0....#.
..#....0....
....0....#..
.#....A.....
...#........
#......#....
........A...
.........A..
..........#.
..........#.";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day08.Solve_1(_input);

        Assert.Equal(14, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day08.Solve_2(_input);

        Assert.Equal(0, result);
    }
}
