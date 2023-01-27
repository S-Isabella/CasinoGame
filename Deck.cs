using System;
using System.Collections.Generic;

namespace CasinoGame
{
    // The deck of the game. 
    public class Deck
    {
        /// <summary>
        /// List of cards in the deck.
        /// </summary>
        public List<Card> Cards { get; set; }

        /// <summary>
        /// List of cards that have already been drawn.
        /// </summary>
        public List<Card> CardsDrawn { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Deck()
        {
            Cards = new List<Card>();
            CardsDrawn = new List<Card>();
            NewDeck(Cards);
        }

        /// <summary>
        /// Creates a new deck with all of the cards.
        /// </summary>
        /// <param name="aCardList">The card list.</param>
        private void NewDeck(List<Card> aCardList)
        {
            // Add all the cards to the deck, each suit (4 in total) having 13 cards each.
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new Card();

                    card.Number = i + 1;
                    switch (j)
                    {
                        case 0:
                            card.Suit = "Clubs";
                            break;
                        case 1:
                            card.Suit = "Hearts";
                            break;
                        case 2:
                            card.Suit = "Diamonds";
                            break;
                        case 3:
                            card.Suit = "Spades";
                            break;
                        default:
                            break;
                    }
                    aCardList.Add(card);
                }
            }
        }

        /// <summary>
        /// Draws a random card and removes it from the deck.
        /// </summary>
        /// <returns>The drawn card.</returns>
        public Card DrawCard()
        {
            // Randomly draw a card from the deck of cards and remove it from the list, adding it instead to list of cards that have been drawn.
            Random random = new Random();
            int randomNumber = random.Next(1, Cards.Count + 1);

            Card card = new Card();
            card = Cards[randomNumber - 1];
            CardsDrawn.Add(card);
            Cards.RemoveAt(randomNumber - 1);

            Console.WriteLine("Card drawn was " + card.Number + " of " + card.Suit);

            return card;
        }

        /// <summary>
        /// We return the drawn cards from the player's and the house's hands unto the playing deck.
        /// </summary>
        public void ReshuffleDeck()
        {
            foreach (var card in CardsDrawn)
            {
                Cards.Add(card);
            }
            CardsDrawn.Clear();
        }
    }
}
