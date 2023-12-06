
string[] fileLines = File.ReadAllLines(args[0]);

// Parse array of seeds
long[] seeds = fileLines[0].Split(' ').Where(s => long.TryParse(s, out _)).Select(s => long.Parse(s)).ToArray();

// Parse maps
Map top_map = new();
Map current_map = top_map;
bool reading_map = false;
for (long i = 1; i < fileLines.Length; i++)
{
    string[] splits = fileLines[i].Split(' ');
    if (!long.TryParse(splits[0], out _))
    {
        if (reading_map)
        {
            current_map.LinkedMap = new();
            current_map = current_map.LinkedMap;
        }
        reading_map = false;
        continue;
    }
    reading_map = true;
    current_map.Ranges.Add(new()
    {
        DestinationRangeStart = long.Parse(splits[0]),
        SourceRangeStart = long.Parse(splits[1]),
        RangeLength = long.Parse(splits[2])
    });
}

// Determine locations for each seed
List<long> locations = [];
for (int i = 0; i < seeds.Length; i++)
{
    long finalDestination = top_map.GetFinalDestination(seeds[i]);
    locations.Add(finalDestination);
}

// Display min location result
if (locations.Count != 0)
{
    Console.WriteLine($"Min location: {locations.Min()}");
}
else
{
    Console.WriteLine("No locations found!");
}

enum MapType {
    SeedToSoil = 0,
    SoilToFertilizer,
    FertilizerToWater,
    WaterToLight,
    LightToTemperature,
    TemperatureToHumidity,
    HumidityToLocation
}

class MapRange
{
    public long DestinationRangeStart { get; set; }
    public long SourceRangeStart { get; set; }
    public long RangeLength { get; set; }

    public bool TryGetDestination(long source, out long destination)
    {
        bool isValid = source >= this.SourceRangeStart && source <= this.SourceRangeStart + this.RangeLength;
        destination = !isValid ? 0 : this.DestinationRangeStart + (source - this.SourceRangeStart);
        return isValid;
    }
}

class Map
{
    public List<MapRange> Ranges { get; set; } = [];

    public Map? LinkedMap { get; set; }

    public Map()
    {
    }

    public Map(Map linkedMap)
    {
        this.LinkedMap = linkedMap;
    }

    public long GetFinalDestination(long source)
    {
        if (this.LinkedMap == null)
        {
            return source;
        }

        List<long> destinations = [];
        foreach (var range in this.Ranges)
        {
            if (range.TryGetDestination(source, out long linkedDestination))
            {
                long destination = this.LinkedMap.GetFinalDestination(linkedDestination);
                destinations.Add(destination);
            }
        }

        if (destinations.Count != 0)
        {
            return destinations.Min();
        }
        else
        {
            return this.LinkedMap.GetFinalDestination(source);
        }
    }
}