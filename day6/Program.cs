static void PartOne(PartOneInput input)
{
    long marginOfError = 1;
    foreach (var stat in input.Stats)
    {
        var winningDistances = stat.GetWinningDistances();
        marginOfError *= winningDistances.Count;
    }
    Console.WriteLine($"Part One Answer: {marginOfError}");
}

static void PartTwo(PartTwoInput input)
{
    var winningDistances = input.Stats.GetWinningDistances();
    Console.WriteLine($"Part Two Answer: {winningDistances.Count}");
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