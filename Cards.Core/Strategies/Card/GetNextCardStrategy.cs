using System.Linq;

namespace Cards.Core.Strategies.Card
{
    public class GetNextCardStrategy : IGetCardStrategy
    {
        public Models.Card GetCard(Models.DeckOfCards deck)
        {
            return deck.Cards.FirstOrDefault();
        }
    }
}