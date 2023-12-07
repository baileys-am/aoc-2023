static void PartOne(PartOneInput input)
{
    int idsSum = 0;
    for (int i = 0; i < input.GameResults.Count; i++)
    {
        if (input.GameResults[i].IsPossibleWith(12, 13, 14))
        {
            idsSum += i + 1;
        }
    }
    Console.WriteLine($"Part One Answer: {idsSum}");
}

static void PartTwo(PartTwoInput input)
{
    long powerSum = 0;
    for (int i = 0; i < input.GameResults.Count; i++)
    {
        powerSum += input.GameResults[i].CalculatePower();
    }
    Console.WriteLine($"Part Two Answer: {powerSum}");
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