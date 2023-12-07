class PartOneInput
{
    public List<long> CalibrationValues { get; set; } = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        char firstDigit = '0', secondDigit = '0';
        foreach (var line in fileLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (long.TryParse(line[i].ToString(), out long _))
                {
                    firstDigit = line[i];
                    break;
                }
            }
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (long.TryParse(line[i].ToString(), out long _))
                {
                    secondDigit = line[i];
                    break;
                }
            }
            this.CalibrationValues.Add(long.Parse($"{firstDigit.ToString()}{secondDigit.ToString()}"));
        }
    }
}

class PartTwoInput
{
    public Dictionary<string, char> NumberLUT = new Dictionary<string, char>() {
        { "zero", '0' },
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' },
    };

    public List<long> CalibrationValues { get; set; } = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        char firstDigit = '0', secondDigit = '0';
        foreach (var line in fileLines)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (long.TryParse(line[i].ToString(), out long _))
                {
                    firstDigit = line[i];
                    break;
                }
                else if (TryGetNumber(line, i, out char n))
                {
                    firstDigit = n;
                    break;
                }
            }
            for (int i = line.Length - 1; i >= 0; i--)
            {
                if (long.TryParse(line[i].ToString(), out long _))
                {
                    secondDigit = line[i];
                    break;
                }
                else if (TryGetNumber(line, i, out char n))
                {
                    secondDigit = n;
                    break;
                }
            }
            this.CalibrationValues.Add(long.Parse($"{firstDigit.ToString()}{secondDigit.ToString()}"));
        }
    }

    public bool TryGetNumber(string str, int pos, out char number)
    {
        number = '0';
        foreach (var key in this.NumberLUT.Keys)
        {
            if (str.Length - pos >= key.Length && key == str.Substring(pos, key.Length))
            {
                number = this.NumberLUT[key];
                return true;
            }
        }
        return false;
    }
}