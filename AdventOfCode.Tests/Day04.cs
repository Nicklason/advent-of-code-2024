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

        Assert.Equal(0, result);
    }
}
