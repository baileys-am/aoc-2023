class CubeCollection(string color, long count)
{
    public string Color { get; set; } = color;
    public long Count { get; set; } = count;
}

class CubeSet
{
    public List<CubeCollection> CubeCollections { get; set; } = [];
}

class GameResult
{
    public List<CubeSet> Sets { get; set; } = [];

    public bool IsPossibleWith(long reds, long greens, long blues)
    {
        foreach (var set in this.Sets)
        {
            foreach (var collection in set.CubeCollections)
            {
                if ((collection.Color == "red" ? collection.Count : 0) > reds ||
                    (collection.Color == "green" ? collection.Count : 0) > greens ||
                    (collection.Color == "blue" ? collection.Count : 0) > blues)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public long CalculatePower()
    {
        long maxRedsUsed = 0, maxGreensUsed = 0, maxBluesUsed = 0;
        foreach (var set in this.Sets)
        {
            foreach (var collection in set.CubeCollections)
            {
                maxRedsUsed = Math.Max(maxRedsUsed, collection.Color == "red" ? collection.Count : 0);
                maxGreensUsed = Math.Max(maxGreensUsed, collection.Color == "green" ? collection.Count : 0);
                maxBluesUsed = Math.Max(maxBluesUsed, collection.Color == "blue" ? collection.Count : 0);
            }
        }
        return maxRedsUsed * maxGreensUsed * maxBluesUsed;
    }
}

class PartOneInput
{
    public List<GameResult> GameResults { get; set; } = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var game in fileLines)
        {
            GameResult gameResult = new();
            foreach (var set in game.Substring(game.IndexOf(':') + 1).Split(';', StringSplitOptions.TrimEntries))
            {
                CubeSet cubeSet = new();
                foreach (var collection in set.Split(',', StringSplitOptions.TrimEntries))
                {
                    var collectionSplit = collection.Split(' ');
                    long count = long.Parse(collectionSplit[0]);
                    string color = collectionSplit[1];
                    cubeSet.CubeCollections.Add(new(color, count));
                }
                gameResult.Sets.Add(cubeSet);
            }
            this.GameResults.Add(gameResult);
        }
    }
}

class PartTwoInput
{
    public List<GameResult> GameResults { get; set; } = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var game in fileLines)
        {
            GameResult gameResult = new();
            foreach (var set in game.Substring(game.IndexOf(':') + 1).Split(';', StringSplitOptions.TrimEntries))
            {
                CubeSet cubeSet = new();
                foreach (var collection in set.Split(',', StringSplitOptions.TrimEntries))
                {
                    var collectionSplit = collection.Split(' ');
                    long count = long.Parse(collectionSplit[0]);
                    string color = collectionSplit[1];
                    cubeSet.CubeCollections.Add(new(color, count));
                }
                gameResult.Sets.Add(cubeSet);
            }
            this.GameResults.Add(gameResult);
        }
    }
}