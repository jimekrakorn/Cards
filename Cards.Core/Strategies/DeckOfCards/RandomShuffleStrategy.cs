using System;
using System.Linq;

namespace Cards.Core.Strategies.DeckOfCards
{
    public class RandomShuffleStrategy : IShuffleStrategy
    {
        public Models.DeckOfCards Shuffle(Models.DeckOfCards deck)
        {
            var shuffleCards = deck.Cards;
            var randomGenerator = new Random();
            var numberOfCards = shuffleCards.Count;
            while (numberOfCards > 1)
            {
                numberOfCards--;

                var randomCardIndex = randomGenerator.Next(numberOfCards + 1);
                var randomCard = shuffleCards[randomCardIndex];

                shuffleCards[randomCardIndex] = shuffleCards[numberOfCards];
                shuffleCards[numberOfCards] = randomCard;
            }
            deck.Cards = shuffleCards;

            return deck;
        }

        public Models.DeckOfCards Shuffle(Models.DeckOfCards deck, int numberOfIterations)
        {
            for (var i = 0; i < numberOfIterations; i++)
            {
                deck = Shuffle(deck);
            }

            return deck;
        }
    }
}