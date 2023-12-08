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
    Console.WriteLine($"Part Two Answer: ");
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