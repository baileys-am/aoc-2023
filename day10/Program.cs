static void PartOne(PartOneInput input)
{
    var start = input.Map.GetStartLocation();
    var nextLoc = input.Map.FindConnections(start, Direction.Any);
    var steps = 1;
    while (nextLoc[0].Item1 != nextLoc[1].Item1)
    {
        input.Map.SetLocationCount(nextLoc[0].Item1, steps);
        input.Map.SetLocationCount(nextLoc[1].Item1, steps);
        // input.Map.Print();
        // Console.WriteLine();
        nextLoc[0] = input.Map.FindConnections(nextLoc[0].Item1, nextLoc[0].Item2)[0];
        nextLoc[1] = input.Map.FindConnections(nextLoc[1].Item1, nextLoc[1].Item2)[0];
        steps++;
    }
    Console.WriteLine($"Part One Answer: {steps}");
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