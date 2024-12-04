namespace AdventOfCode.Tests;

public class Day04
{
    private readonly string _input =
        @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day04.Solve_1(_input);

        Assert.Equal(18, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day04.Solve_2(_input);

        Assert.Equal(9, result);
    }

    [Fact]
    public void CharOfSliceCoordinate()
    {
        var lines = _input.Split(
            "\n",
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries
        );

        var dimensions = (lines[0].Count(), lines.Count());

        var slices = AdventOfCode.Day04.SliceDiagonal(lines, true);
        // It is part of slice 10, and the character index is 1 (SAMM is the slice)
        var result = AdventOfCode.Day04.CharOfSliceCoords(10, 1, dimensions, true);

        // Find the A at x=2, y=1 of the input
        Assert.Equal((2, 1), result);
    }
}
