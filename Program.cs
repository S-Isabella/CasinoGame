using System;

namespace CasinoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Welcome the player and get their name.
                Console.WriteLine("***** Welcome to Isabella's Casino! *****\n\n");

                Console.WriteLine("What is your name?");

                Player player = new Player()
                {
                    Name = Console.ReadLine()
                };

                Console.WriteLine("\n");
                Console.WriteLine("Hi, " + player.Name + "! Let's get you started. You now have 100 tokens to begin.\n\n");

                // Prompt the player for a new round.
                string playerAnswer = "";

                House house = new House();

                PromptForARound(playerAnswer, house, player);
            }
            catch (Exception e)
            {
                Console.WriteLine("The program has encountered an error: " + e.Message);
            }
        }

        /// <summary>
        /// Whether the player or the house have blackjack or have gone over 21.
        /// </summary>
        /// <param name="aHouse">The house.</param>
        /// <param name="aPlayer">The player.</param>
        /// <returns>True someone got blackjack or went over 21.</returns>
        private static bool BlackjackOrOver(House aHouse, Player aPlayer)
        {
            bool aEndOfRound = false;

            // We first check if the player has blackjack
            aEndOfRound = FirstBlackjackOrOver(aHouse, aPlayer);

            // We then check whether the player or the house have over 21 (for the house without the value of the first card as it is not visible until
            // the player chooses to stand).
            if (aPlayer.Hand.TotalSumOfCards > 21)
            {
                Console.WriteLine("You got over 21. You have lost the round.");
                aPlayer.TokenWin(5, false);
                aEndOfRound = true;
            }
            else if (aHouse.SumOfVisibleCards() > 21)
            {
                Console.WriteLine("Congratulations! The house got over 21. You won the round!");
                aPlayer.TokenWin(5, true);
                aEndOfRound = true;
            }
            return aEndOfRound;
        }

        /// <summary>
        /// We check if the player has blackjack with his first two draws, and if the house does as well.
        /// </summary>
        /// <param name="aHouse">The house.</param>
        /// <param name="aPlayer">The player.</param>
        /// <returns>True if the player or the house have blackjack within first two draws.</returns>
        private static bool FirstBlackjackOrOver(House aHouse, Player aPlayer)
        {
            bool aEndOfRound = false;

            // If the player has blackjack, we look at the house's cards and compare.
            if (aPlayer.Hand.TotalSumOfCards == 21)
            {
                if (aHouse.Hand.TotalSumOfCards == 21)
                {
                    Console.WriteLine("Congratulations, " + aPlayer.Name + "! You got blackjack! The house did too so you drew with the house.\n");
                }
                else
                {
                    Console.WriteLine("Congratulations, " + aPlayer.Name + "! You got blackjack!");
                }
                aPlayer.TokenWin(5, true);
                aEndOfRound = true;
            }
            return aEndOfRound;
        }

        /// <summary>
        /// The house and the player play a turn.
        /// </summary>
        /// <param name="aHouse">The house.</param>
        /// <param name="aPlayer">The player.</param>
        /// <param name="aPlayerAnswer">The player's answer.</param>
        private static void PlayTurn(House aHouse, Player aPlayer, string aPlayerAnswer)
        {
            // The dealer(house) deals one card visible to the player, and one card not visible to anyone, for himself. Then the dealer deals one card visible 
            // to the player, and one card visible for himself. 
            for (int i = 0; i < 2; i++)
            {
                aHouse.DrawFromDeckPlayer(aPlayer);
                if (i == 0)
                {
                    aHouse.DrawFromDeckHouse(false);
                }
                else
                {
                    aHouse.DrawFromDeckHouse(true);
                }
            }

            bool endOfRound = false;

            // We first check whether the player started with a blackjack and compare to the house accordingly for a possible draw.
            endOfRound = FirstBlackjackOrOver(aHouse, aPlayer);

            while (!endOfRound)
            {
                Console.WriteLine("The total sum of your cards is " + aPlayer.Hand.TotalSumOfCards + ".\n");
                Console.WriteLine("The sum of the house's visible hand is " + aHouse.SumOfVisibleCards() + "\n");

                Console.WriteLine("What would you like to do next?\n\n1.Stand\n2.Hit me\n\n");

                aPlayerAnswer = Console.ReadLine();

                if (aPlayerAnswer == "1")
                {
                    Console.WriteLine("The total sum of the house's hand is " + aHouse.Hand.TotalSumOfCards + "\n");

                    if (!BlackjackOrOver(aHouse, aPlayer))
                    {
                        ResultsOfRound(aHouse, aPlayer);
                    }
                    endOfRound = true;
                }
                else if (aPlayerAnswer == "2")
                {
                    aHouse.DrawFromDeckPlayer(aPlayer);
                    aHouse.DrawFromDeckHouse(true);
                    endOfRound = BlackjackOrOver(aHouse, aPlayer);
                }
                else
                {
                    Console.WriteLine("Incorrect input.\n");
                }
            }

            // Shuffle the deck and clear the hands.
            aHouse.Deck.ReshuffleDeck();
            aHouse.Hand.ClearHand();
            aPlayer.Hand.ClearHand();

            // Check whether the player has the right amount of tokens to keep playing the game.
            if (aPlayer.Tokens < 5)
            {
                Console.WriteLine("Sorry " + aPlayer.Name + ", but you only have " + aPlayer.Tokens + " left. Minimum wage is 5 tokens. You have lost the game.\n");
            }
            else if (aPlayer.Tokens > 200)
            {
                Console.WriteLine("Congratulations " + aPlayer.Name + "! You have " + aPlayer.Tokens + "(over 200 tokens). You have won the game!\n");
            }
            else
            {
                PromptForARound(aPlayerAnswer, aHouse, aPlayer);
            }
        }

        /// <summary>
        /// Prompt the player for another round.
        /// </summary>
        /// <param name="aAnswer">The answer of the player.</param>
        /// <param name="aHouse">The house.</param>
        /// <param name="aPlayer">The player.</param>
        private static void PromptForARound(string aAnswer, House aHouse, Player aPlayer)
        {
            Console.WriteLine("Would you like to play a round? The wage is 5 tokens. Answer \'y\' for yes and \'n\' for no.");
            aAnswer = Console.ReadLine();
            Console.WriteLine("\n");

            if (aAnswer == "y")
            {
                PlayTurn(aHouse, aPlayer, aAnswer);
            }
            else if (aAnswer == "n")
            {
                // We say goodbye and exit the game.
                Console.WriteLine("Goodbye! Press any key to exit the game.");
                if (Console.ReadLine() != null)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                // We let the player know he put an incorrect input, and ask him to try again.
                Console.WriteLine("Incorrect input. Please try again.\n");
                PromptForARound(aAnswer, aHouse, aPlayer);
            }
        }

        /// <summary>
        /// Whether the player has won or lost the round.
        /// </summary>
        /// <param name="aHouse">The house.</param>
        /// <param name="aPlayer">The player.</param>
        private static void ResultsOfRound(House aHouse, Player aPlayer)
        {
            if (aHouse.Hand.TotalSumOfCards == 21)
            {
                Console.WriteLine("The house got blackjack! You have lost the round.");
                aPlayer.TokenWin(5, false);
            }
            else if (aHouse.Hand.TotalSumOfCards > 21)
            {
                Console.WriteLine("The house got over 21. Congratulations! You beat the house!");
                aPlayer.TokenWin(5, true);
            }
            else if (aPlayer.Hand.TotalSumOfCards > aHouse.Hand.TotalSumOfCards)
            {
                Console.WriteLine("Congratulations! You got a higher number. You beat the house!");
                aPlayer.TokenWin(5, true);
            }
            else if (aPlayer.Hand.TotalSumOfCards == aHouse.Hand.TotalSumOfCards)
            {
                Console.WriteLine("Congratulations! You drew with the house.");
                aPlayer.TokenWin(5, true);
            }
            else if (aPlayer.Hand.TotalSumOfCards < aHouse.Hand.TotalSumOfCards)
            {
                Console.WriteLine("The house got a higher number. You have lost the round.");
                aPlayer.TokenWin(5, false);
            }
        }
    }
}
