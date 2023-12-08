class Scratchcard
{
    public List<long> WinningNumbers { get; set; } = [];
    public List<long> YourNumbers { get; set; } = [];

    public long CalculatePoints()
    {
        long matchCount = 0;
        foreach (var yourNum in this.YourNumbers)
        {
            if (this.WinningNumbers.Any(n => n == yourNum))
            {
                matchCount++;
            }
        }
        if (matchCount > 0)
        {
            return (long)Math.Pow(2, matchCount - 1);
        }
        else
        {
            return 0;
        }
    }
}

class PartOneInput
{
    public List<Scratchcard> Scratchcards { get; set ;} = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var line in fileLines)
        {
            var nums = line[(line.IndexOf(": ") + 2)..].Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            this.Scratchcards.Add(new()
            {
                WinningNumbers = nums[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(n => long.Parse(n)).ToList(),
                YourNumbers = nums[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(n => long.Parse(n)).ToList()
            });
        }
    }
}

class PartTwoInput
{

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
    }
}