namespace CasinoGame
{
    // The cards in the deck.
    public class Card
    {
        /// <summary>
        /// The number of the card.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// The suit the card is part of.
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Card()
        {
            Number = 0;
            Suit = "";
        }
    }
}
