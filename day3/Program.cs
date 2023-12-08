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
    long gearRatioSum = 0;
    foreach (var symbol in input.Symbols)
    {
        int adjacentPartCount = 0;
        long gearRatio = 1;
        foreach (var part in input.PartNumbers)
        {
            if (symbol.IsAdjacentTo(part))
            {
                adjacentPartCount++;
                gearRatio *= part.Number;
                if (adjacentPartCount > 2)
                {
                    break;
                }
            }
        }

        if (adjacentPartCount == 2)
        {
            gearRatioSum += gearRatio;
        }
    }
    Console.WriteLine($"Part One Answer: {gearRatioSum}");
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