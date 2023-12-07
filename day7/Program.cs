static void PartOne(PartOneInput input)
{
    var rankedHands = input.Hands.OrderBy(h => (long)h.HandType)
                                 .ThenBy(h => h.Strength)
                                 .ToList();
    long totalWinnings = 0;
    for (int i = 0; i < rankedHands.Count; i++)
    {
        totalWinnings += (i + 1) * rankedHands[i].Bid;
    }

    Console.WriteLine($"Part One Answer: {totalWinnings}");
}

static void PartTwo(PartTwoInput input)
{
    var rankedHands = input.Hands.OrderBy(h => (long)h.HandType)
                                 .ThenBy(h => h.Strength)
                                 .ToList();
    long totalWinnings = 0;
    for (int i = 0; i < rankedHands.Count; i++)
    {
        totalWinnings += (i + 1) * rankedHands[i].Bid;
    }

    Console.WriteLine($"Part Two Answer: {totalWinnings}");
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