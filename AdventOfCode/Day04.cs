namespace AdventOfCode;

using System.Text.RegularExpressions;

public class Day04 : BaseDay
{
    private readonly string _input;

    private static readonly Regex regex1 = new Regex(@"XMAS");
    private static readonly Regex regex2 = new Regex(@"SAMX");
    private static readonly Regex regex3 = new Regex(@"SAM");
    private static readonly Regex regex4 = new Regex(@"MAS");

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public static string[] SliceHorizontal(string[] lines)
    {
        return lines;
    }

    public static string[] SliceVertical(string[] lines)
    {
        var width = lines[0].Count();
        var height = lines.Count();

        var slices = new string[width];

        for (var x = 0; x < width; x++)
        {
            var slice = "";
            for (var y = 0; y < height; y++)
            {
                slice += lines[y][x];
            }

            slices[x] = slice;
        }

        return slices;
    }

    public static string[] SliceDiagonal(string[] lines, bool leftToRight)
    {
        var width = lines[0].Count();
        var height = lines.Count();

        var slices = new string[width + height - 1];

        var x = 0;
        var y = 0;

        for (var i = 0; i < width + height - 1; i++)
        {
            if (i < height)
            {
                x = 0;
                y = height - i - 1;
            }
            else
            {
                x = i - height + 1;
                y = 0;
            }

            var slice = "";

            var z = x;
            for (; y < height; y++)
            {
                slice += lines[y][leftToRight ? z : width - z - 1];

                z++;
                if (z >= height)
                {
                    z = 0;
                    break;
                }
            }

            slices[i] = slice;
        }

        return slices;
    }

    public static (int, int) CharOfSliceCoordinate(
        int sliceIndex,
        int charIndex,
        int width,
        int height,
        bool leftToRight
    )
    {
        var x = 0;
        var y = 0;

        if (sliceIndex < height)
        {
            x = charIndex;
            y = height - sliceIndex - 1 + charIndex;
        }
        else
        {
            x = sliceIndex - height + 1 + charIndex;
            y = charIndex;
        }

        if (!leftToRight)
        {
            x = width - x - 1;
        }

        return (x, y);
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

        SliceHorizontal(lines).ToList().ForEach(slices.Add);
        SliceVertical(lines).ToList().ForEach(slices.Add);
        SliceDiagonal(lines, false).ToList().ForEach(slices.Add);
        SliceDiagonal(lines, true).ToList().ForEach(slices.Add);

        var count = 0;
        for (var i = 0; i < slices.Count; i++)
        {
            count += regex1.Count(slices[i]) + regex2.Count(slices[i]);
        }

        return count;
    }

    public static int Solve_2(string input)
    {
        var lines = input.Split(
            "\n",
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
        );

        var width = lines[0].Length;
        var height = lines.Length;

        var slices1 = SliceDiagonal(lines, false);
        var slices2 = SliceDiagonal(lines, true);

        var possible = new HashSet<(int, int)>();

        for (var i = 0; i < slices1.Count(); i++)
        {
            regex3
                .Matches(slices1[i])
                .ToList()
                .ForEach(match =>
                    possible.Add(CharOfSliceCoordinate(i, match.Index + 1, width, height, false))
                );

            regex4
                .Matches(slices1[i])
                .ToList()
                .ForEach(match =>
                    possible.Add(CharOfSliceCoordinate(i, match.Index + 1, width, height, false))
                );
        }

        var count = 0;

        for (var i = 0; i < slices2.Count(); i++)
        {
            count += regex3
                .Matches(slices2[i])
                .ToList()
                .FindAll(match =>
                    possible.Contains(
                        CharOfSliceCoordinate(i, match.Index + 1, width, height, true)
                    )
                )
                .Count();

            count += regex4
                .Matches(slices2[i])
                .ToList()
                .FindAll(match =>
                    possible.Contains(
                        CharOfSliceCoordinate(i, match.Index + 1, width, height, true)
                    )
                )
                .Count();
        }

        return count;
    }

    public override ValueTask<string> Solve_1() => new(Day04.Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Day04.Solve_2(_input).ToString());
}
