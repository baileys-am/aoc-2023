class RaceStats(long time, long distance)
{
    public long Time { get; set; } = time;
    public long Distance { get; set; } = distance;

    public List<long> GetWinningDistances()
    {
        List<long> distances = [];
        for (long holdTime = 0; holdTime < this.Time; holdTime++)
        {
            long speed = holdTime;
            long remainingTime = this.Time - holdTime;
            long distance = speed * remainingTime;
            distances.Add(distance);
        }
        return distances.Where(t => t > this.Distance).ToList();
    }
}

class PartOneInput
{
    public List<RaceStats> Stats { get; set ; } = [];

    public PartOneInput(string filepath)
    {
        // Parse stats
        string[] fileLines = File.ReadAllLines(filepath);
        string[] timeSplit = fileLines[0].Split(' ', StringSplitOptions.TrimEntries)
                                         .Skip(1)
                                         .Where(s => !string.IsNullOrWhiteSpace(s))
                                         .ToArray();
        string[] distanceSplit = fileLines[1].Split(' ', StringSplitOptions.TrimEntries)
                                             .Skip(1)
                                             .Where(s => !string.IsNullOrWhiteSpace(s))
                                             .ToArray();
        for (int i = 0; i < timeSplit.Length; i++)
        {
            this.Stats.Add(new (long.Parse(timeSplit[i]), long.Parse(distanceSplit[i])));
        }
    }
}

class PartTwoInput
{
    public RaceStats Stats { get; set ; }

    public PartTwoInput(string filepath)
    {
        // Parse stats
        string[] fileLines = File.ReadAllLines(filepath);
        string timeStr = fileLines[0].Split(' ', StringSplitOptions.TrimEntries)
                                     .Skip(1)
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .Aggregate((s1, s2) => $"{s1}{s2}");
        string distStr = fileLines[1].Split(' ', StringSplitOptions.TrimEntries)
                                     .Skip(1)
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .Aggregate((s1, s2) => $"{s1}{s2}");
        this.Stats = new(long.Parse(timeStr), long.Parse(distStr));
    }
}