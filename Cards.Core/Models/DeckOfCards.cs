using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Cards.Core.Constants;
using Cards.Core.Enums;
using Cards.Core.Strategies.Card;
using Cards.Core.Strategies.DeckOfCards;

namespace Cards.Core.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DeckOfCards : ValidationAttribute
    {
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards
        {
            get { return _cards
                .Where(c => !c.HasBeenPlayed)
                .ToList(); }
            set { _cards = value; }
        }

        public DeckOfCards()
        {
            PopulateDeck();
        }

        public DeckOfCards(bool shuffleCards)
        {
            PopulateDeck();

            if (shuffleCards) 
                ShuffleCards(new RandomShuffleStrategy());
        }

        public Card GetCard(IGetCardStrategy strategy)
        {
            var nextCard =  strategy.GetCard(this);

            if (nextCard != null)
            {
                nextCard.HasBeenPlayed = true;
            }

            return nextCard;
        }

        public void ShuffleCards(IShuffleStrategy shuffleStrategy)
        {
            _cards = shuffleStrategy.Shuffle(this, 100)._cards;
        }

        private void PopulateDeck()
        {
            for (var rankIndex = CardRank.Two; rankIndex <= CardRank.Ace; rankIndex++)
                for (var suitIndex = CardSuit.Hearts; suitIndex <= CardSuit.Clubs; suitIndex++)
                    _cards.Add(new Card(rankIndex, suitIndex));
        }

        private bool CorrectNumberOfCardsAreInTheDeck()
        {
            return !(_cards.Count > GlobalConstants.MaxCardsPerDeck || _cards.Count < 1);
        }

        private bool ExactlyOneOfEachCardInTheDeck()
        {
            var ranks = Enum.GetValues(typeof(CardRank));
            var suits = Enum.GetValues(typeof(CardSuit));
            var oneOfEachCardInTheDeck = false;

            foreach (CardRank rank in ranks)
            {
                foreach (CardSuit suit in suits)
                {
                    try
                    {
                        oneOfEachCardInTheDeck = (_cards.Single(c => c.Rank == rank && c.Suit == suit)) != null;
                    }
                    catch (Exception)
                    {
                        oneOfEachCardInTheDeck = false;
                    }
                }
            }

            return oneOfEachCardInTheDeck;
        }

        public override bool IsValid(object value)
        {
            var allIsWell = CorrectNumberOfCardsAreInTheDeck();

            if (allIsWell)
                allIsWell = ExactlyOneOfEachCardInTheDeck();

            return allIsWell;
        }
    }
}