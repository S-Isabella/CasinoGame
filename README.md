# Casino Game

Casino Game is a C# console application that represents a Blackjack game.

## Installation

Clone from git repository and open and run in Visual Studio 2019.

## Usage

The rules of the game are the following:
	1. The player is asked for their name and given 100 tokens to start with.
	2. The player is asked whether they want to begin a turn. 
		i. They can either accept or decline and exit the game.
	3. The turn begins.
		i. During a turn, the house draws one visible-to-all card for the player, and one visible-to-none card for himself. Then, another visible-to-all card is drawn for both
		the player and himself (only the first card drawn for the house is not visible). A check is done on whether the player got blackjack (sum of all cards is 21), and if so,
		we compare with the house's hand for a possible draw. 
		ii. The player is then prompted on whether they want to either 1. Stand or 2. Hit me.
			a) Stand means the player bets their current hand agaisnt the hand of the house. 
				1. The player can either win the round with blackjack (can draw if both get one or both have same sum), a higher hand than the house, or if the house goes over 21. 
			b) Hit me means we draw again, one card each, both visible-to-all. 
		iii. This prompt is repeated until the player either 'stands' or the player or the house either hit blackjack or the sum of their hand goes over 21, which means they lost.
	4. The player is then asked if they want to play another turn.
	5. The game ends once the player either wins with 200 or more tokens, loses with less than 5 tokens (the minimum wager), or when prompted for another turn they choose to decline
	with 'n'.
