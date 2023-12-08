class PartNumber(string number, long xPos, long yPos)
{
    public string NumberStr { get; set; } = number;
    public long Number { get; set; } = long.Parse(number);
    public long XPosition { get; set; } = xPos;
    public long YPosition { get; set; } = yPos;
    public long XLength { get; set; } = number.Length;

    public bool IsAdjacentTo(Symbol symbol)
    {
        if (symbol.YPosition >= this.YPosition - 1 && symbol.YPosition <= this.YPosition + 1)
        {
            for (long x = symbol.XPosition; x < symbol.XPosition + symbol.XLength; x++)
            {
                if (x >= this.XPosition - 1 && x <= this.XPosition + this.XLength)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}

class Symbol(string symbol, long xPos, long yPos)
{
    public string SymbolStr { get; set; } = symbol;
    public long XPosition { get; set; } = xPos;
    public long YPosition { get; set; } = yPos;
    public long XLength { get; set; } = symbol.Length;

    public bool IsAdjacentTo(PartNumber part)
    {
        if (part.YPosition >= this.YPosition - 1 && part.YPosition <= this.YPosition + 1)
        {
            for (long x = part.XPosition; x < part.XPosition + part.XLength; x++)
            {
                if (x >= this.XPosition - 1 && x <= this.XPosition + this.XLength)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            return false;
        }
    }
}

class PartOneInput
{
    public List<PartNumber> PartNumbers { get; set ;} = [];
    public List<Symbol> Symbols { get; set ;} = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);

        // Find symbols
        for (int i = 0; i < fileLines.Length; i++)
        {
            var lineSplit = fileLines[i].Split(['.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
            int xPos = 0;
            for (int j = 0; j < lineSplit.Length; j++)
            {
                var substr = lineSplit[j];
                if (!string.IsNullOrEmpty(substr))
                {
                    int substrIndex = fileLines[i].IndexOf(substr, xPos);
                    this.Symbols.Add(new(substr, substrIndex, i));
                    xPos = substrIndex + substr.Length;
                }
            }
        }

        // Find part numbers
        for (int i = 0; i < fileLines.Length; i++)
        {
            var lineSplit = fileLines[i].Split([".", .. this.Symbols.Select(s => s.SymbolStr).ToList()], StringSplitOptions.None);
            int xPos = 0;
            for (int j = 0; j < lineSplit.Length; j++)
            {
                var substr = lineSplit[j];
                if (!string.IsNullOrEmpty(substr))
                {
                    int substrIndex = fileLines[i].IndexOf(substr, xPos);
                    this.PartNumbers.Add(new(substr, substrIndex, i));
                    xPos = substrIndex + substr.Length;
                }
            }
        }
    }
}

class PartTwoInput
{
    public List<PartNumber> PartNumbers { get; set ;} = [];
    public List<Symbol> Symbols { get; set ;} = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);

        // Find symbols
        for (int i = 0; i < fileLines.Length; i++)
        {
            var lineSplit = fileLines[i].Split(['.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
            int xPos = 0;
            for (int j = 0; j < lineSplit.Length; j++)
            {
                var substr = lineSplit[j];
                if (!string.IsNullOrEmpty(substr))
                {
                    int substrIndex = fileLines[i].IndexOf(substr, xPos);
                    this.Symbols.Add(new(substr, substrIndex, i));
                    xPos = substrIndex + substr.Length;
                }
            }
        }

        // Find part numbers
        for (int i = 0; i < fileLines.Length; i++)
        {
            var lineSplit = fileLines[i].Split([".", .. this.Symbols.Select(s => s.SymbolStr).ToList()], StringSplitOptions.None);
            int xPos = 0;
            for (int j = 0; j < lineSplit.Length; j++)
            {
                var substr = lineSplit[j];
                if (!string.IsNullOrEmpty(substr))
                {
                    int substrIndex = fileLines[i].IndexOf(substr, xPos);
                    this.PartNumbers.Add(new(substr, substrIndex, i));
                    xPos = substrIndex + substr.Length;
                }
            }
        }
    }
}