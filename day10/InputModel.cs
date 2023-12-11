enum Direction
{
    Any,
    Up,
    Down,
    Left,
    Right
}

class Map(List<string> rows)
{
    public List<string> Rows { get; set; } = rows;
    public List<string> CountRows { get; set; } = [.. rows];
    public List<string> MaskRows { get; set; } = rows.Select(r => new string('.', r.Length)).ToList();

    public List<((int, int), Direction)> FindConnections((int, int) loc, Direction direction)
    {
        int x = loc.Item1;
        int y = loc.Item2;
        char type = this.Rows[y][x];
        List<((int, int), Direction)> connections = [];

        // Check top
        if (direction != Direction.Down && y - 1 >= 0)
        {
            char neighborType = this.Rows[y - 1][x];
            switch (type)
            {
                case '|':
                case 'J':
                case 'L':
                case 'S':
                    if (neighborType == '|' || neighborType == '7' || neighborType == 'F')
                    {
                        connections.Add(((x, y - 1), Direction.Up));
                    }
                    break;
                default:
                    break;
            }
        }
        
        // Check down
        if (direction != Direction.Up && y + 1 < this.Rows.Count)
        {
            char neighborType = this.Rows[y + 1][x];
            switch (type)
            {
                case '|':
                case '7':
                case 'F':
                case 'S':
                    if (neighborType == '|' || neighborType == 'J' || neighborType == 'L')
                    {
                        connections.Add(((x, y + 1), Direction.Down));
                    }
                    break;
                default:
                    break;
            }
        }

        // Check left
        if (direction != Direction.Right && x - 1 >= 0)
        {
            char neighborType = this.Rows[y][x - 1];
            switch (type)
            {
                case '-':
                case '7':
                case 'J':
                case 'S':
                    if (neighborType == 'F' || neighborType == '-' || neighborType == 'L')
                    {
                        connections.Add(((x - 1, y), Direction.Left));
                    }
                    break;
                default:
                    break;
            }
        }

        // Check right
        if (direction != Direction.Left && x + 1 < this.Rows[0].Length)
        {
            char neighborType = this.Rows[y][x + 1];
            switch (type)
            {
                case '-':
                case 'L':
                case 'F':
                case 'S':
                    if (neighborType == '-' || neighborType == 'J' || neighborType == '7')
                    {
                        connections.Add(((x + 1, y), Direction.Right));
                    }
                    break;
                default:
                    break;
            }
        }

        if (connections.Count > 2)
        {
            throw new Exception("oops");
        }

        return connections;
    }

    public (int, int) GetStartLocation()
    {
        for (int y = 0; y < this.Rows.Count; y++)
        {
            int x = this.Rows[y].IndexOf('S');
            if (x >= 0)
            {
                return new(x, y);
            }
        }
        throw new Exception("oops");
    }

    public void SetLocationCount((int, int) loc, int count)
    {
        int x = loc.Item1;
        int y = loc.Item2;
        count = count > 9 ? 0 : count;
        this.CountRows[y] = $"{this.CountRows[y][..x]}{count}{this.CountRows[y][(x + 1)..]}";
    }

    public void SetMask((int, int) loc, char mask)
    {
        int x = loc.Item1;
        int y = loc.Item2;
        this.MaskRows[y] = $"{this.MaskRows[y][..x]}{mask}{this.MaskRows[y][(x + 1)..]}";
    }

    public void Print()
    {
        Console.WriteLine("Map count:");
        foreach (var row in this.CountRows)
        {
            Console.WriteLine(row);
        }
    }

    public void PrintMask()
    {
        Console.WriteLine("Map mask:");
        foreach (var row in this.MaskRows)
        {
            Console.WriteLine(row);
        }
    }

    public int CountEnclosedTiles()
    {
        return 0;
    }
}

class PartOneInput
{
    public Map Map { get; set; }

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        this.Map = new([.. fileLines]);
    }
}

class PartTwoInput
{
    public Map Map { get; set; }

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        this.Map = new([.. fileLines]);
    }
}