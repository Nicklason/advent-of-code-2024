namespace AdventOfCode.Tests;

public class Day06
{
    private readonly string _input =
        @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day06.Solve_1(_input);

        Assert.Equal(41, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day06.Solve_2(_input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Loops()
    {
        var (map, start) = AdventOfCode.Day06.Parse(_input);

        map[(3, 6)] = '#';

        var path = AdventOfCode.Day06.Path(map, start);

        Assert.True(path.loop);
    }
}
