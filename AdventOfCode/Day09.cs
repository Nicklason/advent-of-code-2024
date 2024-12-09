namespace AdventOfCode;

using FileSystem = List<int>;

public class Day09 : BaseDay
{
    private readonly string _input;

    public Day09()
    {
        _input = File.ReadAllText(InputFilePath).Trim();
    }

    public static FileSystem Parse(string input)
    {
        var filesystem = new FileSystem();

        for (var i = 0; i < input.Length; i++)
        {
            var blockSize = input[i] - '0';
            var toAdd = (i % 2 == 1) ? -1 : i / 2;
            filesystem.AddRange(Enumerable.Repeat(toAdd, blockSize));
        }

        return filesystem;
    }

    public static long Solve_1(string input)
    {
        var filesystem = Parse(input);

        var head = 0;
        var tail = filesystem.Count - 1;

        do
        {
            while (filesystem[tail] == -1)
            {
                tail--;
            }

            while (filesystem[head] != -1)
            {
                head++;
            }

            if (head >= tail)
            {
                break;
            }

            var temp = filesystem[tail];
            filesystem[tail] = filesystem[head];
            filesystem[head] = temp;
        } while (head < tail);

        long checksum = 0;
        for (var i = 0; i < filesystem.Count; i++)
        {
            if (filesystem[i] == -1)
            {
                continue;
            }
            checksum += filesystem[i] * i;
        }

        return checksum;
    }

    public static int Solve_2(string input)
    {
        return 0;
    }

    public override ValueTask<string> Solve_1() => new(Solve_1(_input).ToString());

    public override ValueTask<string> Solve_2() => new(Solve_2(_input).ToString());
}
