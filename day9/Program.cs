static void PartOne(PartOneInput input)
{
    long extrapSum = 0;
    foreach (var value in input.Values)
    {
        extrapSum += value.Extrapolate();
    }
    Console.WriteLine($"Part One Answer: {extrapSum}");
}

static void PartTwo(PartTwoInput input)
{
    long extrapSum = 0;
    foreach (var value in input.Values)
    {
        extrapSum += value.ExtrapolateBackwards();
    }
    Console.WriteLine($"Part OnTwo Answer: {extrapSum}");
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