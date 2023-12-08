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

    public long GetMatchCount()
    {
        long matchCount = 0;
        foreach (var yourNum in this.YourNumbers)
        {
            if (this.WinningNumbers.Any(n => n == yourNum))
            {
                matchCount++;
            }
        }
        return matchCount;
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
    public List<Scratchcard> Scratchcards { get; set ;} = [];

    public PartTwoInput(string filepath)
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

    public long CardCeption(int currentCard)
    {
        long cardCount = 0;
        long matchCount = this.Scratchcards[currentCard].GetMatchCount();
        if (matchCount > 0)
        {
            cardCount += matchCount;
            for (int j = currentCard + 1; j < Math.Min(this.Scratchcards.Count, currentCard + matchCount + 1); j++)
            {
                cardCount += this.CardCeption(j);
            }
        }
        return cardCount;
    }
}