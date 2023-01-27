using System.Collections.Generic;

namespace CasinoGame
{
    // The hand of a player or of the house.
    public class Hand : Deck
    {
        /// <summary>
        /// The total sum of cards in the hand.
        /// </summary>
        public int TotalSumOfCards { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Hand()
        {
            Cards = new List<Card>();
            TotalSumOfCards = 0;
        }

        /// <summary>
        /// Adds a card to the hand.
        /// </summary>
        /// <param name="aCard">Card to add to the hand.</param>
        public void AddCard(Card aCard)
        {
            Cards.Add(aCard);
            TotalSumOfCards += ValueOfCard(aCard, TotalSumOfCards);
        }

        /// <summary>
        /// Clears the hand and its sum.
        /// </summary>
        public void ClearHand()
        {
            Cards.Clear();
            TotalSumOfCards = 0;
        }

        /// <summary>
        /// Obtains the value of the card.
        /// </summary>
        /// <param name="aCard">The card from which we want to know the value of.</param>
        /// <param name="aTotalSum">The sum which we're comparing it to for the value of the Ace cards.</param>
        /// <returns>The value of the card.</returns>
        public int ValueOfCard(Card aCard, int aTotalSum)
        {
            int valueOfCard = 0;

            if (aCard.Number == 11 || aCard.Number == 12 || aCard.Number == 13)
            {
                valueOfCard = 10;
            }
            else if (aCard.Number != 1)
            {
                valueOfCard = aCard.Number;
            }
            else
            {
                if (aTotalSum <= 10)
                {
                    valueOfCard = 11;
                }
                else valueOfCard = 1;
            }
            return valueOfCard;
        }
    }
}
