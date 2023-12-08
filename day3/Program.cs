static void PartOne(PartOneInput input)
{
    long partNumSum = 0;
    foreach (var part in input.PartNumbers)
    {
        foreach (var symbol in input.Symbols)
        {
            if (part.IsAdjacentTo(symbol))
            {
                partNumSum += part.Number;
                break;
            }
        }
    }
    Console.WriteLine($"Part One Answer: {partNumSum}");
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