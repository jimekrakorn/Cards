using Cards.Core.Strategies.CardHand;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cards.Core.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CardHand : ValidationAttribute, ICardHand
    {
        private readonly List<Card> _cards;

        public List<Card> Cards
        {
            get { return _cards; }
        } 

        public CardHand()
        {
            _cards = new List<Card>();
        }

        public int Count
        {
            get { return _cards.Count; }
        }

        public int HandRank
        {
            get
            {
                var ranksStrategy = new SumOfAllCardRanksStrategy(this);
                return ranksStrategy.Calculate();
            }
        }

        public override bool IsValid(object value)
        {
            return _cards != null;
        }

        public Card AddCard(Card card)
        {
            if (card == null)
            {
                return null;
            }

            _cards.Add(card);

            return card;
        }

        public Card RemoveCard(Card card)
        {
            if (card == null)
            {
                return null;
            }
            return _cards.Remove(card) ? card : null;
        }
    }
}
