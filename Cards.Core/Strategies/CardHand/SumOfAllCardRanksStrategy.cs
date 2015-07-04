using System.Linq;

namespace Cards.Core.Strategies.CardHand
{
    public class SumOfAllCardRanksStrategy : ICardHandRankStrategy
    {
        private readonly Models.CardHand _hand;

        public SumOfAllCardRanksStrategy(Models.CardHand hand)
        {
            _hand = hand;
        }

        public int Calculate()
        {
            return _hand.Cards.Sum(c => (int)c.Rank);
        }
    }

}
