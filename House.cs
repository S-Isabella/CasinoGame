using System;

namespace CasinoGame
{
    // The house has its own hand and deals from a deck for both the player and the house.
    public class House
    {
        /// <summary>
        /// The deck the house deals with.
        /// </summary>
        public Deck Deck { get; set; }

        /// <summary>
        /// The house's hand.
        /// </summary>
        public Hand Hand { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public House()
        {
            Hand = new Hand();
            Deck = new Deck();
        }

        /// <summary>
        /// Draws from the deck and adds to the house's hand.
        /// </summary>
        /// <param name="aVisible">Whether the card is visible to the player or not.</param>
        public void DrawFromDeckHouse(bool aVisible)
        {
            Card card = new Card();
            card = Deck.DrawCard();
            this.Hand.AddCard(card);
            
            if (aVisible)
            {
                if (card.Number == 1)
                {
                    Console.WriteLine("The house has drawn an Ace of " + card.Suit + ".\n");
                }
                else if (card.Number == 11)
                {
                    Console.WriteLine("The house has drawn a Jack of " + card.Suit + ".\n");
                }
                else if (card.Number == 12)
                {
                    Console.WriteLine("The house has drawn a Queen of " + card.Suit + ".\n");
                }
                else if (card.Number == 13)
                {
                    Console.WriteLine("The house has drawn a King of " + card.Suit + ".\n");
                }
                else
                {
                    Console.WriteLine("The house has drawn a " + card.Number + " of " + card.Suit + ".\n");
                }
            }
            else
            {
                Console.WriteLine("The house has drawn a card.\n");
            }
        }

        /// <summary>
        /// Draws from the deck and adds to the player's hand.
        /// </summary>
        /// <param name="aPlayer">The player to draw a card for.</param>
        public void DrawFromDeckPlayer(Player aPlayer)
        {
            Card card = new Card();
            card = Deck.DrawCard();
            aPlayer.Hand.AddCard(card);

            if (card.Number == 1)
            {
                Console.WriteLine("You have drawn an Ace of " + card.Suit + ".\n");
            }
            else if (card.Number == 11)
            {
                Console.WriteLine("You have drawn a Jack of " + card.Suit + ".\n");
            }
            else if (card.Number == 12)
            {
                Console.WriteLine("You have drawn a Queen of " + card.Suit + ".\n");
            }
            else if (card.Number == 13)
            {
                Console.WriteLine("You have drawn a King of " + card.Suit + ".\n");
            }
            else
            {
                Console.WriteLine("You have drawn a " + card.Number + " of " + card.Suit + ".\n");
            }
        }

        /// <summary>
        /// The sum of the cards of the house's hand without the first non visible card.
        /// </summary>
        /// <returns>The total sum of visible cards.</returns>
        public int SumOfVisibleCards()
        {
            int totalSumOfVisibleCards = 0;

            for (int i = 0; i < this.Hand.Cards.Count; i++)
            {
                if (i != 0)
                {
                    totalSumOfVisibleCards += this.Hand.ValueOfCard(this.Hand.Cards[i], totalSumOfVisibleCards);
                }
            }

            return totalSumOfVisibleCards;
        }
    }
}
