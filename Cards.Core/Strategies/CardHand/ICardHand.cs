using System.Collections.Generic;

namespace Cards.Core.Strategies.CardHand
{
    public interface ICardHand
    {
        List<Models.Card> Cards { get; }
        int Count { get; }
        int HandRank { get; }
        bool IsValid(object value);
        Models.Card AddCard(Models.Card card);
        Models.Card RemoveCard(Models.Card card);
    }
}