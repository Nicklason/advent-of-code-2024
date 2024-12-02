namespace AdventOfCode.Tests;

public class Day02
{
    private readonly string _input =
        @"
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day02.Solve_1(_input);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day02.Solve_2(_input);

        Assert.Equal(4, result);
    }
}
