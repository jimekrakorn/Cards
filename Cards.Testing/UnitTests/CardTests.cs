using Cards.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cards.Core.Models;

namespace Cards.Testing.UnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_ValidRankAndSuitProvided_SuccessCardCreatedWithValidRankSuit()
        {
            // Arrange
            const CardRank rank = CardRank.Ace;
            const CardSuit suit = CardSuit.Spades;

            // Act
            var card = new Card(rank, suit);

            // Assert
            Assert.IsNotNull(card);
            Assert.AreEqual(CardRank.Ace, card.Rank);
            Assert.AreEqual(CardSuit.Spades, card.Suit);
        }

        [TestMethod]
        public void Card_InvalidRankAndValidSuitProvided_FailureCardIsValidReturnsFalse()
        {
            // Arrange
            const CardRank rank = (CardRank)18;
            const CardSuit suit = CardSuit.Hearts;

            // Act
            var card = new Card(rank, suit);
           
            // Assert
            Assert.IsFalse(card.IsValid(card.Rank));
        }

        [TestMethod]
        public void Card_ValidRankAndInvalidSuitProvided_FailureCardIsValidReturnsFalse()
        {
            // Arrange
            const CardRank rank = CardRank.Ace;
            const CardSuit suit = (CardSuit)100;

            // Act
            var card = new Card(rank, suit);

            // Assert
            Assert.IsFalse(card.IsValid(card.Suit));
        }

        [TestMethod]
        public void Card_InvalidRankAndInvalidSuitProvided_FailureCardIsValidReturnsFalse()
        {
            // Arrange
            const CardRank rank = (CardRank)100;
            const CardSuit suit = (CardSuit)200;

            // Act
            var card = new Card(rank, suit);

            // Assert
            Assert.IsNotNull(card);
            Assert.IsFalse(card.IsValid(card));
        }
    }
}