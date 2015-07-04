using System.Collections.Generic;
using System.Linq;
using Cards.Core.Enums;
using Cards.Core.Models;
using Cards.Core.Strategies.Card;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cards.Testing.UnitTests
{
    [TestClass]
    public class DeckOfCardsTests
    {
        [TestMethod]
        public void DeckOfCards_NoConstructorOptions_SuccessDeckOfCardsCreatedWithValidCards()
        {
            // Arrange

            // Act
            var deck = new DeckOfCards();

            // Assert
            Assert.IsNotNull(deck);
            Assert.IsTrue(deck.IsValid(deck));
        }

        [TestMethod]
        public void DeckOfCards_ShuffleCardsOptionsFalse_SuccessDeckOfCardsCreatedSortedByAscendingSuitAndRank()
        {
            // Arrange

            // Act
            var deck = new DeckOfCards(false);

            // Assert
            Assert.IsNotNull(deck);
            Assert.IsTrue(!VerifyCardsAreOutOfOrder(deck));
        }

        [TestMethod]
        public void DeckOfCards_ShuffleCardsOptionsTrue_SuccessDeckOfCardsCreatedNotSortedByAscendingSuitAndRank()
        {
            // Arrange

            // Act
            var deck = new DeckOfCards(true);

            // Assert
            Assert.IsNotNull(deck);
            Assert.IsTrue(VerifyCardsAreOutOfOrder(deck));
        }

        private static bool VerifyCardsAreOutOfOrder(DeckOfCards deck)
        {
            var sortedDeck = new DeckOfCards().Cards;

            return deck.Cards
                .Where((t, i) => 
                    !(sortedDeck[i].Rank == t.Rank || 
                      sortedDeck[i].Suit == t.Suit))
                .Any();
        }

        [TestMethod]
        public void GetCard_GetRandomCardStrategy_SuccessRandomCardReturnedAndMarkedAsPlayed()
        {
            // Arrange
            var deck = new DeckOfCards(true);

            // Act
            var newCard = deck.GetCard(new GetRandomCardStrategy());

            // Assert
            Assert.IsNotNull(newCard);
            Assert.IsTrue(newCard.HasBeenPlayed);
            Assert.AreEqual(51, deck.Cards.Count);
        }

        [TestMethod]
        public void GetCard_GetNextCardStrategy_SuccessRandomCardReturnedAndMarkedAsPlayed()
        {
            // Arrange
            var deck = new DeckOfCards(true);

            // Act
            var newCard = deck.GetCard(new GetNextCardStrategy());

            // Assert
            Assert.IsNotNull(newCard);
            Assert.IsTrue(newCard.HasBeenPlayed);
            Assert.AreEqual(51, deck.Cards.Count);
        }

        [TestMethod]
        public void GetCard_ZeroCardsRemainingInDeck_FailureReturnsNull()
        {
            // Arrange
            var deck = new DeckOfCards(true);
            Card newCard;

            // Act
            for (int i = 0; i < 52; i++)
            {
                newCard = deck.GetCard(new GetNextCardStrategy());
            }
            newCard = deck.GetCard(new GetNextCardStrategy());

            // Assert
            Assert.AreEqual(0, deck.Cards.Count);
            Assert.IsNull(newCard);
        }

        [TestMethod]
        public void IsValid_DeckOfCardsHasGreaterThan52Cards_FailureReturnsFalse()
        {
            // Arrange
            var deck = new DeckOfCards();
            var tempCards = deck.Cards;

            // Act
            tempCards.Add(new Card(CardRank.Ace, CardSuit.Spades));
            deck.Cards = tempCards;

            // Assert
            Assert.AreEqual(53, deck.Cards.Count);
            Assert.IsFalse(deck.IsValid(deck));
        }

        [TestMethod]
        public void IsValid_DeckOfCardsHasMoreThanOneCardOfSameRankAndSuit_FailureReturnsFalse()
        {
            // Arrange
            var deck = new DeckOfCards();
            var tempCards = new List<Card>
            {
                new Card(CardRank.Ace, CardSuit.Spades),
                new Card(CardRank.Ace, CardSuit.Spades)
            };

            // Act
            deck.Cards = tempCards;

            // Assert
            Assert.IsFalse(deck.IsValid(deck));
        }
    }
}