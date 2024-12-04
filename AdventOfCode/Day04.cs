namespace AdventOfCode;

using System.Text.RegularExpressions;

public class Day04 : BaseDay
{
    private readonly string _input;

    private static readonly Regex regex1 = new Regex(@"XMAS");
    private static readonly Regex regex2 = new Regex(@"SAMX");

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static int Solve_1(string input)
    {
        var lines = input.Split(
            "\n",
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        );

        var width = lines[0].Length;
        var height = lines.Length;

        var slices = new List<string>();

        var x = 0;
        var y = 0;

        // Horizontal lines
        for (y = 0; y < height; y++)
        {
            slices.Add(lines[y]);
        }

        // Vertical lines
        for (x = 0; x < width; x++)
        {
            var slice = "";
            for (y = 0; y < height; y++)
            {
                slice += lines[y][x];
            }

            slices.Add(slice);
        }

        // Down right from top
        for (x = 0; x < width; x++)
        {
            var slice = "";

            var z = x;
            for (y = 0; y < height; y++)
            {
                slice += lines[y][z];

                z++;
                if (z >= height)
                {
                    z = 0;
                    break;
                }
            }

            slices.Add(slice);
        }

        // Down right from left
        for (y = 1; y < height; y++)
        {
            var slice = "";

            var z = y;
            for (x = 0; x < width; x++)
            {
                slice += lines[z][x];

                z++;
                if (z >= width)
                {
                    z = 0;
                    break;
                }
            }

            slices.Add(slice);
        }

        // Down left from top
        for (x = width - 1; x >= 0; x--)
        {
            var slice = "";

            var z = x;
            for (y = 0; y < height; y++)
            {
                slice += lines[y][z];

                z--;
                if (z < 0)
                {
                    break;
                }
            }

            slices.Add(slice);
        }

        // Down right from left
        for (y = 1; y < height; y++)
        {
            var slice = "";

            var z = y;
            for (x = width - 1; x >= 0; x--)
            {
                slice += lines[z][x];

                z++;
                if (z >= height)
                {
                    break;
                }
            }

            slices.Add(slice);
        }

        var count = 0;
        for (var i = 0; i < slices.Count; i++)
        {
            count += regex1.Count(slices[i]) + regex2.Count(slices[i]);
        }

        return count;
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Day04.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day04.Solve_2(_input).ToString());
}
