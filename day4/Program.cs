static void PartOne(PartOneInput input)
{
    long cardPointsSum = 0;
    foreach (var card in input.Scratchcards)
    {
        cardPointsSum += card.CalculatePoints();
    }
    Console.WriteLine($"Part One Answer: {cardPointsSum}");
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