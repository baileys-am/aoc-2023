class PartOneInput
{
    public List<string> Rows { get; set; } = [];
    public List<(int X, int Y)> Stars { get; set; } = [];
    public List<int> ExpandedRows { get; set; } = [];
    public List<int> ExpandedCols { get; set; } = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        List<int> newCols = [];
        for (int i = 0; i < fileLines[0].Length; i++)
        {
            if (fileLines.All(l => l[i] == '.'))
            {
                newCols.Add(i);
            }
        }
        for (int i = 0; i < newCols.Count; i++)
        {
            var adjustedCol = newCols[i] + i;
            for (int j = 0; j < fileLines.Length; j++)
            {
                fileLines[j] = $"{fileLines[j][..adjustedCol]}{'.'}{fileLines[j][(adjustedCol)..]}";
            }
        }
        foreach (var line in fileLines)
        {
            this.Rows.Add(line);
            if (line.All(c => c == '.'))
            {
                this.Rows.Add(line);
            }
            else
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != '.')
                    {
                        this.Stars.Add(new(i, this.Rows.Count - 1));
                    }
                }
            }
        }
    }

    public static int CalcDistance((int X, int Y) here, (int X, int Y) there)
    {
        var xDisplacement = Math.Abs(here.X - there.X);
        var yDisplacement = Math.Abs(here.Y - there.Y);
        return xDisplacement + yDisplacement;
    }

    public long Solve()
    {
        long totalDistances = 0;
        for (int i = 0; i < this.Stars.Count; i++)
        {
            for (int j = i + 1; j < this.Stars.Count; j++)
            {
                totalDistances += CalcDistance(this.Stars[i], this.Stars[j]);
            }
        }
        return totalDistances;
    }
}

class PartTwoInput
{
    public List<(int X, int Y)> Stars { get; set; } = [];
    public List<int> ExpandedRows { get; set; } = [];
    public List<int> ExpandedCols { get; set; } = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        for (int i = 0; i < fileLines[0].Length; i++)
        {
            if (fileLines.All(l => l[i] == '.'))
            {
                this.ExpandedCols.Add(i);
            }
        }
        for (int i = 0; i < fileLines.Length; i++)
        {
            if (fileLines[i].All(c => c == '.'))
            {
                this.ExpandedRows.Add(i);
            }
        }
        for (int i = 0; i < fileLines.Length; i++)
        {
            for (int j = 0; j < fileLines[i].Length; j++)
            {
                if (fileLines[i][j] != '.')
                {
                    this.Stars.Add(new(j, i));
                }
            }
        }
    }

    public int CalcDistance((int X, int Y) here, (int X, int Y) there)
    {
        var expanseMultiplier = 1000000;
        var xDisplacement = 0;
        var yDisplacement = 0;
        for (int col = Math.Min(here.X, there.X) + 1; col <= Math.Max(here.X, there.X); col++)
        {
            xDisplacement += this.ExpandedCols.Contains(col) ? expanseMultiplier : 1;
        }
        for (int row = Math.Min(here.Y, there.Y) + 1; row <= Math.Max(here.Y, there.Y); row++)
        {
            yDisplacement += this.ExpandedRows.Contains(row) ? expanseMultiplier : 1;
        }
        return xDisplacement + yDisplacement;
    }

    public long Solve()
    {
        long totalDistances = 0;
        for (int i = 0; i < this.Stars.Count; i++)
        {
            for (int j = i + 1; j < this.Stars.Count; j++)
            {
                totalDistances += CalcDistance(this.Stars[i], this.Stars[j]);
            }
        }
        return totalDistances;
    }
}