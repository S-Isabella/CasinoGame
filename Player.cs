using System;

namespace CasinoGame
{
    // The player.
    public class Player
    {
        /// <summary>
        /// The player's playing hand.
        /// </summary>
        public Hand Hand { get; set; }

        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The player's tokens.
        /// </summary>
        public int Tokens { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        public Player()
        {
            Hand = new Hand();
            Tokens = 100;
        }

        /// <summary>
        /// According to whether the player won or lost the turn, gains or loses a certain amount of tokens.
        /// </summary>
        /// <param name="aAmountWaged">Amount of token the player waged this turn.</param>
        /// <param name="aWon">Whether the player won or not.</param>
        public void TokenWin(int aAmountWaged, bool aWon)
        {
            if (aWon)
            {
                Tokens += aAmountWaged * 2;
            }
            else
            {
                Tokens -= aAmountWaged;
            }
            Console.WriteLine("You now have " + Tokens + " tokens.\n");
        }
    }
}
