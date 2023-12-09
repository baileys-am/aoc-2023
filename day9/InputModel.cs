class OasisValue
{
    public List<long> History { get; set; } = [];

    public long Extrapolate()
    {
        List<long> lastNums = [ this.History.Last() ];
        List<long> diffs = [.. this.History];
        while (diffs.Count == this.History.Count || diffs.Distinct().Count() != 1)
        {
            for (int i = 1; i < diffs.Count; i++)
            {
                diffs[i - 1] = diffs[i] - diffs[i - 1];
            }
            diffs.RemoveAt(diffs.Count - 1);
            lastNums.Add(diffs.Last());
        }
        var nextValue = lastNums.Sum();
        return nextValue;
    }

    public long ExtrapolateBackwards()
    {
        List<long> firstNums = [ this.History.First() ];
        List<long> diffs = [.. this.History];
        while (diffs.Count == this.History.Count || diffs.Distinct().Count() != 1)
        {
            for (int i = 1; i < diffs.Count; i++)
            {
                diffs[i - 1] = diffs[i] - diffs[i - 1];
            }
            diffs.RemoveAt(diffs.Count - 1);
            firstNums.Add(diffs.First());
        }
        var prevValue = firstNums.Select((item, index) => index % 2 == 0 ? item : -item).Sum();
        return prevValue;
    }
}

class PartOneInput
{
    public List<OasisValue> Values { get; set ;} = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var line in fileLines)
        {
            this.Values.Add(new()
            {
                History = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                              .Select(n => long.Parse(n))
                              .ToList()
            });
        }
    }
}

class PartTwoInput
{
    public List<OasisValue> Values { get; set ;} = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var line in fileLines)
        {
            this.Values.Add(new()
            {
                History = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                              .Select(n => long.Parse(n))
                              .ToList()
            });
        }
    }
}