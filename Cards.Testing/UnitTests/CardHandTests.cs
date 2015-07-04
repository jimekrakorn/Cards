using Cards.Core.Models;
using Cards.Core.Strategies.Card;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cards.Testing.UnitTests
{
    [TestClass]
    public class CardHandTests 
    {
        [TestMethod]
        public void CardHand_DefaultOptions_SuccessCardHandCreatedWithNoCards()
        {
            // Arrange

            // Act
            var cardHand = new CardHand();

            // Assert
            Assert.IsNotNull(cardHand);
            Assert.AreEqual(0, cardHand.Count);
            Assert.IsTrue(cardHand.IsValid(cardHand));
        }

        [TestMethod]
        public void AddCard_ValidCardProvided_SuccessCardAddedCardToHand()
        {
            // Arrange
            var deck = new DeckOfCards(true);
            var cardHand = new CardHand();
            
            // Act
            cardHand.AddCard(deck.GetCard(new GetRandomCardStrategy()));

            // Assert
            Assert.AreEqual(1, cardHand.Count);
        }

        [TestMethod]
        public void AddCard_InvalidCardProvided_FailureCardNothingAddedCardToHand()
        {
            // Arrange
            var cardHand = new CardHand();

            // Act
            var addedCard = cardHand.AddCard(null);

            // Assert
            Assert.IsNull(addedCard);
            Assert.AreEqual(0, cardHand.Count);
        }

        [TestMethod]
        public void RemoveCard_ValidCardProvided_SuccessCardRemovedCardFromHand()
        {
            // Arrange
            const int numCards = 4;
            Card addedCard = null;
            var deck = new DeckOfCards(true);
            var cardHand = new CardHand();

            for (var i = 0; i < numCards; i++)
            {
               addedCard = cardHand.AddCard(deck.GetCard(new GetNextCardStrategy())); 
            }
            

            // Act
            var removedCard = cardHand.RemoveCard(addedCard);

            // Assert
            Assert.IsNotNull(removedCard);
            Assert.AreEqual(numCards - 1, cardHand.Count);
        }

        [TestMethod]
        public void RemoveCard_InvalidCardProvided_FailureCardNotRemovedFromHand()
        {
            // Arrange
            var cardHand = new CardHand();


            // Act
            var removedCard = cardHand.RemoveCard(null);

            // Assert
            Assert.IsNull(removedCard);
        }

        [TestMethod]
        public void HandRank_Valid4CardHandProvided_SuccessSumOfCardRanksReturned() 
        { 
            // Arrange
            var deck = new DeckOfCards();
            var hand = new CardHand();
            
            for (var cardIndex = 0; cardIndex < 4; cardIndex++)
            {
                // Note: In an unshuffled deck, the 1st four cards are all deuces
                hand.AddCard(deck.GetCard(new GetNextCardStrategy()));
            }
            
            
            // Act
            var rank = hand.HandRank;
            
            // Assert
            Assert.AreEqual(4, hand.Count);
            Assert.AreEqual(8, rank);
        }
    }
}
