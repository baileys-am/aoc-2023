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

static bool IsPointInPolygon((int X, int Y) p, List<(int X, int Y)> polygon)
{
    double minX = polygon[0].X;
    double maxX = polygon[0].X;
    double minY = polygon[0].Y;
    double maxY = polygon[0].Y;
    for (int i = 1; i < polygon.Count; i++)
    {
        var q = polygon[i];
        minX = Math.Min(q.X, minX);
        maxX = Math.Max(q.X, maxX);
        minY = Math.Min(q.Y, minY);
        maxY = Math.Max(q.Y, maxY);
    }

    if (p.X < minX || p.X > maxX || p.Y < minY || p.Y > maxY)
    {
        return false;
    }

    // thank you SO: https://stackoverflow.com/questions/217578/how-can-i-determine-whether-a-2d-point-is-within-a-polygon
    // https://wrf.ecse.rpi.edu/Research/Short_Notes/pnpoly.html
    bool inside = false;
    for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
    {
        if ((polygon[i].Y > p.Y) != (polygon[j].Y > p.Y) &&
             p.X < (polygon[j].X - polygon[i].X) * (p.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X)
        {
            inside = !inside;
        }
    }

    return inside;
}

static void PartTwo(PartTwoInput input)
{
    var polygons = new List<(int, int)>();
    var start = input.Map.GetStartLocation();
    polygons.Add(start);
    input.Map.SetMask(start, 'X');
    var nextLoc = input.Map.FindConnections(start, Direction.Any);
    input.Map.SetMask(nextLoc[0].Item1, 'X');
    input.Map.SetMask(nextLoc[1].Item1, 'X');
    polygons.Insert(0, nextLoc[0].Item1);
    polygons.Add(nextLoc[1].Item1);
    var steps = 1;
    while (nextLoc[0].Item1 != nextLoc[1].Item1)
    {
        nextLoc[0] = input.Map.FindConnections(nextLoc[0].Item1, nextLoc[0].Item2)[0];
        nextLoc[1] = input.Map.FindConnections(nextLoc[1].Item1, nextLoc[1].Item2)[0];
        input.Map.SetMask(nextLoc[0].Item1, 'X');
        input.Map.SetMask(nextLoc[1].Item1, 'X');
        polygons.Insert(0, nextLoc[0].Item1);
        polygons.Add(nextLoc[1].Item1);
        steps++;
    }
    polygons.RemoveAt(polygons.Count - 1);

    int enclosedTileCount = 0;
    for (int y = 0; y < input.Map.MaskRows.Count; y++)
    {
        for (int x = 0; x < input.Map.MaskRows[y].Length; x++)
        {
            if (input.Map.MaskRows[y][x] != 'X')
            {
                if (IsPointInPolygon((x, y), polygons))
                {
                    input.Map.SetMask((x, y), 'I');
                    enclosedTileCount++;
                }
            }
        }
    }
    input.Map.PrintMask();
    Console.WriteLine();

    Console.WriteLine($"Part Two Answer: {enclosedTileCount}");
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