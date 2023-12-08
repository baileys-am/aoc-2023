class Node(string left, string right)
{
    public string LeftNode { get; set; } = left;
    public string RightNode { get; set; } = right;
}

class PartOneInput
{
    public string Instructions { get; set; }
    public Dictionary<string, Node> Nodes { get; set; } = [];
    public string StartNodeId { get; set; } = "";

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        this.Instructions = fileLines[0];

        for (int i = 2; i < fileLines.Length; i++)
        {
            var lineSplit = fileLines[i].Split('=', StringSplitOptions.TrimEntries);
            var nodeId = lineSplit[0];
            if (i == 2)
            {
                this.StartNodeId = nodeId;
            }
            var lrSplit = lineSplit[1].Split([",", "(", ")"], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            this.Nodes[nodeId] = new(lrSplit[0], lrSplit[1]);
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