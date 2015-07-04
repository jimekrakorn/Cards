namespace Cards.Core.Strategies.DeckOfCards
{
    public interface IShuffleStrategy
    {
        Models.DeckOfCards Shuffle(Models.DeckOfCards deck);
        Models.DeckOfCards Shuffle(Models.DeckOfCards deck, int numberOfIterations);
    }
}
