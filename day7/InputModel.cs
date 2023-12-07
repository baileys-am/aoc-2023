enum HandType
{
    HighCard = 1,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    FullHouse,
    FourOfAKind,
    FiveOfAKind
}

class Hand
{
    public Dictionary<char, long> CardStrengthLUT = new()
    {
        { 'A', 13 }, { 'K', 12 }, { 'Q', 11 }, { 'J', 10 },
        { 'T', 9 }, { '9', 8 }, { '8', 7 }, { '7', 6 },
        { '6', 5 }, { '5', 4 }, { '4', 3 }, { '3', 2 }, { '2', 1 }
    };

    public string Cards { get; set; }
    public long Bid { get; set; }
    public HandType HandType { get; set; }
    public long Strength { get; set; }

    public Hand(string cards, long bid)
    {
        this.Cards = cards;
        this.Bid = bid;

        // Count cards
        Dictionary<char, long> cardCounts = [];
        foreach (var card in this.Cards)
        {
            if (!cardCounts.TryGetValue(card, out long value))
            {
                cardCounts[card] = 1;
            }
            else
            {
                cardCounts[card] = ++value;
            }
        }

        // Determine type/strength
        var distinctCards = cardCounts.Keys.Count;
        var sortedCards = cardCounts.OrderByDescending(kvp => kvp.Value)
                                    .ThenByDescending(kvp => this.CardStrengthLUT[kvp.Key])
                                    .Select(kvp => kvp.Key)
                                    .ToList();
        var sortedValues = cardCounts.OrderByDescending(kvp => kvp.Value)
                                     .ThenByDescending(kvp => this.CardStrengthLUT[kvp.Key])
                                     .Select(kvp => kvp.Value)
                                     .ToList();
        this.Strength = 3200000 * this.CardStrengthLUT[this.Cards[0]] + 
                        160000 * this.CardStrengthLUT[this.Cards[1]] + 
                        8000 * this.CardStrengthLUT[this.Cards[2]] + 
                        400 * this.CardStrengthLUT[this.Cards[3]] + 
                        20 * this.CardStrengthLUT[this.Cards[4]];
        if (distinctCards == 5)
        {
            this.HandType =  HandType.HighCard;
        }
        else if (distinctCards == 4)
        {
            this.HandType =  HandType.OnePair;
        }
        else if (distinctCards == 3 &&
                 sortedValues[0] == 2 &&
                 sortedValues[1] == 2)
        {
            this.HandType =  HandType.TwoPair;
        }
        else if (distinctCards == 3 &&
                 sortedValues[0] == 3)
        {
            this.HandType =  HandType.ThreeOfAKind;
        }
        else if (distinctCards == 2 &&
                 sortedValues[0] == 3)
        {
            this.HandType =  HandType.FullHouse;
        }
        else if (distinctCards == 2 &&
                 sortedValues[0] == 4)
        {
            this.HandType =  HandType.FourOfAKind;
        }
        else if (distinctCards == 1)
        {
            this.HandType =  HandType.FiveOfAKind;
        }
        else
        {
            throw new Exception("oops");
        }
    }
}

class WildcardHand
{
    public Dictionary<char, long> CardStrengthLUT = new()
    {
        { 'A', 13 }, { 'K', 12 }, { 'Q', 11 }, { 'T', 10 },
        { '9', 9 }, { '8', 8 }, { '7', 7 }, { '6', 6 },
        { '5', 5 }, { '4', 4 }, { '3', 3 }, { '2', 2 }, { 'J', 1 }
    };

    public string ActualCards { get; set; }
    public string Cards { get; set; }
    public long Bid { get; set; }
    public HandType HandType { get; set; }
    public long Strength { get; set; }

    public WildcardHand(string cards, long bid)
    {
        this.ActualCards = cards;
        this.Cards = cards;
        this.Bid = bid;

        // Handle wildcards
        if (this.ActualCards.Any(c => c == 'J'))
        {
            var sortedWildCards = this.ActualCards.Distinct();

        }

        // Count cards
        Dictionary<char, long> cardCounts = [];
        foreach (var card in this.Cards)
        {
            if (!cardCounts.TryGetValue(card, out long value))
            {
                cardCounts[card] = 1;
            }
            else
            {
                cardCounts[card] = ++value;
            }
        }

        // Determine type/strength
        var distinctCards = cardCounts.Keys.Count;
        var sortedCards = cardCounts.OrderByDescending(kvp => kvp.Value)
                                    .ThenByDescending(kvp => this.CardStrengthLUT[kvp.Key])
                                    .Select(kvp => kvp.Key)
                                    .ToList();
        var sortedValues = cardCounts.OrderByDescending(kvp => kvp.Value)
                                     .ThenByDescending(kvp => this.CardStrengthLUT[kvp.Key])
                                     .Select(kvp => kvp.Value)
                                     .ToList();
        int jokerIndex = sortedCards.FindIndex(c => c == 'J');
        if (jokerIndex >= 0)
        {
            int nonJokerIndex = sortedCards.FindIndex(c => c != 'J');
            if (nonJokerIndex >= 0)
            {
                sortedValues[nonJokerIndex] += sortedValues[jokerIndex];
                sortedCards.RemoveAt(jokerIndex);
                sortedValues.RemoveAt(jokerIndex);
                distinctCards--;
            }
            else
            {
                sortedCards[0] = 'A';
            }
        }
        this.Strength = 3200000 * this.CardStrengthLUT[this.ActualCards[0]] + 
                        160000 * this.CardStrengthLUT[this.ActualCards[1]] + 
                        8000 * this.CardStrengthLUT[this.ActualCards[2]] + 
                        400 * this.CardStrengthLUT[this.ActualCards[3]] + 
                        20 * this.CardStrengthLUT[this.ActualCards[4]];
        if (distinctCards == 5)
        {
            this.HandType =  HandType.HighCard;
        }
        else if (distinctCards == 4)
        {
            this.HandType =  HandType.OnePair;
        }
        else if (distinctCards == 3 &&
                 sortedValues[0] == 2 &&
                 sortedValues[1] == 2)
        {
            this.HandType =  HandType.TwoPair;
        }
        else if (distinctCards == 3 &&
                 sortedValues[0] == 3)
        {
            this.HandType =  HandType.ThreeOfAKind;
        }
        else if (distinctCards == 2 &&
                 sortedValues[0] == 3)
        {
            this.HandType =  HandType.FullHouse;
        }
        else if (distinctCards == 2 &&
                 sortedValues[0] == 4)
        {
            this.HandType =  HandType.FourOfAKind;
        }
        else if (distinctCards == 1)
        {
            this.HandType =  HandType.FiveOfAKind;
        }
        else
        {
            throw new Exception("oops");
        }
    }
}

class PartOneInput
{
    public List<Hand> Hands { get; set; } = [];

    public PartOneInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var line in fileLines)
        {
            string[] lineSplit = line.Split(' ');
            this.Hands.Add(new(lineSplit[0], long.Parse(lineSplit[1])));
        }
    }
}

class PartTwoInput
{
    public List<WildcardHand> Hands { get; set; } = [];

    public PartTwoInput(string filepath)
    {
        // Parse
        string[] fileLines = File.ReadAllLines(filepath);
        foreach (var line in fileLines)
        {
            string[] lineSplit = line.Split(' ');
            this.Hands.Add(new(lineSplit[0], long.Parse(lineSplit[1])));
        }
    }
}