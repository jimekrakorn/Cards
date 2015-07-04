using System;

namespace Cards.Core.Strategies.Card
{
    public class GetRandomCardStrategy : IGetCardStrategy
    {
        public Models.Card GetCard(Models.DeckOfCards deck)
        {
            var randomGenerator = new Random();
            var randomCardIndex = randomGenerator.Next(deck.Cards.Count + 1);
            var nextCard = deck.Cards[randomCardIndex];

            return nextCard;
        }
    }
}