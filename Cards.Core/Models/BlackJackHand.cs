using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Core.Strategies.CardHand;

namespace Cards.Core.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class BlackJackHand : ValidationAttribute, ICardHand
    {
        public BlackJackHand(List<Card> cards, int count, int handRank)
        {
            HandRank = handRank;
            Count = count;
            Cards = cards;
        }

        public List<Card> Cards { get; private set; }
        public int Count { get; private set; }
        public int HandRank { get; private set; }
        public override bool IsValid(object value)
        {
            throw new NotImplementedException();
        }

        public Card AddCard(Card card)
        {
            throw new NotImplementedException();
        }

        public Card RemoveCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}