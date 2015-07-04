using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cards.Core.Enums;

namespace Cards.Core.Models
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class Card : ValidationAttribute
    {
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public bool HasBeenPlayed { get; set; }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
            HasBeenPlayed = false;
        }

        public override bool IsValid(object value)
        {
            return (Rank >= CardRank.Two && Rank <= CardRank.Ace) &&
                   (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds || Suit == CardSuit.Spades || Suit == CardSuit.Clubs);
        }
    }
}
