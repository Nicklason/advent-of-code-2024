namespace AdventOfCode.Tests;

public class Day03
{
    private readonly string _input =
        "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    [Fact]
    public void Solve_1()
    {
        var result = AdventOfCode.Day03.Solve_1(_input);

        Assert.Equal(161, result);
    }

    [Fact]
    public void Solve_2()
    {
        var result = AdventOfCode.Day03.Solve_2(_input);

        Assert.Equal(0, result);
    }
}
