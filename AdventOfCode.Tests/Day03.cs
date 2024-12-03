namespace AdventOfCode.Tests;

public class Day03
{
    [Fact]
    public void Solve_1()
    {
        var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var result = AdventOfCode.Day03.Solve_1(input);

        Assert.Equal(161, result);
    }

    [Fact]
    public void Solve_2()
    {
        var input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        var result = AdventOfCode.Day03.Solve_2(input);

        Assert.Equal(48, result);
    }

    [Fact]
    public void Solve_2_Edgecase()
    {
        var input = "mul(2,4don't()do())";

        var result = AdventOfCode.Day03.Solve_2(input);

        Assert.Equal(0, result);
    }
}
