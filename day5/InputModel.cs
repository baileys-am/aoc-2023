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
            List<long> mydestinations = [];
            foreach (var range in this.Ranges)
            {
                if (range.TryGetDestination(source, out long linkedDestination))
                {
                    mydestinations.Add(linkedDestination);
                }
            }
            if (mydestinations.Count != 0)
            {
                return mydestinations.Min();
            }
            else
            {
                return source;
            }
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

class PartOneInput
{
    public long[] Seeds { get; set; }

    public Map TopMap { get; set; } = new();

    public PartOneInput(string filepath)
    {
        string[] fileLines = File.ReadAllLines(filepath);

        // Parse seeds
        this.Seeds = fileLines[0].Split(' ').Where(s => long.TryParse(s, out _)).Select(s => long.Parse(s)).ToArray();

        // Parse maps
        Map current_map = this.TopMap;
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
    }
}

class SeedPair(long start, long length)
{
    public long Start { get; set; } = start;
    public long Length { get; set; } = length;
}

class PartTwoInput
{
    public List<SeedPair> SeedPairs { get; set; } = [];

    public Map TopMap { get; set; } = new();

    public PartTwoInput(string filepath)
    {
        string[] fileLines = File.ReadAllLines(filepath);

        // Parse seeds
        this.SeedPairs = [.. fileLines[0].Split(' ')
                                         .Where(s => long.TryParse(s, out _))
                                         .Select(s => long.Parse(s))
                                         .Chunk(2)
                                         .Select(c => new SeedPair(c[0], c[1]))
                                         .OrderBy(k => k.Start)];
        for (int i = 1; i < this.SeedPairs.Count; i++)
        {
            if (this.SeedPairs[i - 1].Start + this.SeedPairs[i - 1].Length >= this.SeedPairs[i].Start)
            {
                this.SeedPairs[i - 1].Length = this.SeedPairs[i].Start - this.SeedPairs[i - 1].Start - 1;
            }
        }

        // Parse maps
        Map current_map = this.TopMap;
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
    }
}