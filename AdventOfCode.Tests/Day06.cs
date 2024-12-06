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

        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Dimensions()
    {
        var dimensions = AdventOfCode.Day06.Dimensions(_input);

        Assert.Equal((10,10), dimensions);
    }

    [Fact]
    public void IndexToPosition()
    {
        var dimensions = AdventOfCode.Day06.Dimensions(_input);
        
        var index = _input.Length - 1;

        var pos = AdventOfCode.Day06.IndexToPosition(index, dimensions);

        Assert.Equal((9, 9), pos);
    }

    [Fact]
    public void PositionToIndex()
    {
        var dimensions = AdventOfCode.Day06.Dimensions(_input);
        var guardIndex = _input.IndexOf("^");
 
        var guardPos = (4,6);

        var calculatedGuardIndex = AdventOfCode.Day06.PositionToIndex(guardPos, dimensions);

        Assert.Equal(calculatedGuardIndex, guardIndex);
    }
}
