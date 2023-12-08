static void PartOne(PartOneInput input)
{
    string start = "AAA";
    string end = "ZZZ";
    string currentPosition = start;
    int currentInstruction = 0;
    long stepCount = 0;
    while (currentPosition != end)
    {
        stepCount++;
        currentPosition = input.Instructions[currentInstruction] switch
        {
            'L' => input.Nodes[currentPosition].LeftNode,
            'R' => input.Nodes[currentPosition].RightNode,
            _ => throw new Exception("oops!")
        };
        currentInstruction = currentInstruction + 1 >= input.Instructions.Length ? 0 : currentInstruction + 1;
    }

    Console.WriteLine($"Part One Answer: {stepCount}");
}

static void PartTwo(PartTwoInput input)
{
    // Thank you SO: https://stackoverflow.com/questions/147515/least-common-multiple-for-3-or-more-numbers/29717490#29717490
    static long LCM(long[] numbers)
    {
        return numbers.Aggregate(lcm);
    }
    static long lcm(long a, long b)
    {
        return Math.Abs(a * b) / GCD(a, b);
    }
    static long GCD(long a, long b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

    char start = 'A';
    char end = 'Z';
    var startNodes = input.Nodes.Keys.Where(k => k[2] == start).ToList();
    Dictionary<string, long> cyclicLUT = [];
    foreach (var node in startNodes)
    {
        string currentPosition = node;
        int currentInstruction = 0;
        long stepCount = 0;
        while (currentPosition[2] != end)
        {
            stepCount++;
            currentPosition = input.Instructions[currentInstruction] switch
            {
                'L' => input.Nodes[currentPosition].LeftNode,
                'R' => input.Nodes[currentPosition].RightNode,
                _ => throw new Exception("oops!")
            };
            currentInstruction = currentInstruction + 1 >= input.Instructions.Length ? 0 : currentInstruction + 1;
        }
        cyclicLUT[node] = stepCount;
    }

    long overallStepCount = LCM([.. cyclicLUT.Values]);
    Console.WriteLine($"Part Two Answer: {overallStepCount}");
}

Console.WriteLine("Running part one...");
PartOneInput partOne = new(args[0]);
var watch = System.Diagnostics.Stopwatch.StartNew();
PartOne(partOne);
Console.WriteLine($"Part one finished: {watch.ElapsedMilliseconds}ms");

Console.WriteLine("\nRunning part two...");
watch = System.Diagnostics.Stopwatch.StartNew();
PartTwoInput partTwo = new(args[0]);
PartTwo(partTwo);
watch.Stop();
Console.WriteLine($"Part two finished: {watch.ElapsedMilliseconds}ms");