static void PartOne(PartOneInput input)
{
    List<long> locations = [];
    for (int i = 0; i < input.Seeds.Length; i++)
    {
        long finalDestination = input.TopMap.GetFinalDestination(input.Seeds[i]);
        locations.Add(finalDestination);
    }
    Console.WriteLine($"Part One Answer: {locations.Min()}");
}

static void PartTwo(PartTwoInput input)
{
    long minLocation = long.MaxValue;
    for (int i = 0; i < input.SeedPairs.Count; i++)
    {
        Console.WriteLine($"Seed pair started: {i}");
        for (long seed = input.SeedPairs[i].Start; seed < input.SeedPairs[i].Start + input.SeedPairs[i].Length; seed++)
        {
            long finalDestination = input.TopMap.GetFinalDestination(seed);
            if (finalDestination < minLocation)
            {
                minLocation = finalDestination;
                Console.WriteLine($"New min location: {minLocation}");
            }
        }
        Console.WriteLine($"Seed pair finished: {i}");
    }
    Console.WriteLine($"Part Two Answer: {minLocation}");
}

PartOneInput partOne = new(args[0]);
PartOne(partOne);

PartTwoInput partTwo = new(args[0]);
PartTwo(partTwo);