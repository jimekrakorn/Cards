namespace Cards.Core.Strategies.Card
{
    public interface IGetCardStrategy
    {
        Models.Card GetCard(Models.DeckOfCards deck);
    }
}