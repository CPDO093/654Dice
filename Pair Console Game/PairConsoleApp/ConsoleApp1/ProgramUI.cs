using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Game...");
            RollGame game = new RollGame();
            // Introduce the game to the user
            string intro = @"
            The Game\n"+
            "Any number of players will take three turns rolling a collection of five dice hoping to match numbers 4, 5, and 6.\n"+
            "The player has exactly THREE rolls to obtain a 4, 5, and 6 - and if that player obtains all three numbers within\n"+
             "three rolls - that player can now start accumulating points.\n"+
             "The player cannot accumulate points without acquiring the three numbers 4, 5, 6, first.\n"+
             "The game can end in a draw. There is only one round for each player.";
            Console.WriteLine(intro);
            bool playAgain = true;
            while (playAgain)
            {
                for (int player = 1; player <= game.numberOfPlayers; player++)
                {
                    // Display Whos Turn
                    DisplayWhosTurnItIs(player);
                    while (game.numberOfTurns > 0)
                    {
                        // Display Remaining Roles
                        DisplayRemainingTurns(game.numberOfTurns);
                        // Press Enter To Roll
                        Console.ReadKey();
                        List<int> rolled = game.RollDice(game.numberOfDice);
                        // Display what we rolled
                        DisplayDiceRolled(rolled);
                        // Gather Dice Data From Roll
                        for (int di = 0; di < rolled.Count - 1; di++)
                        {
                            // Only remove one di per match if not matched
                            if (game.runTimeManager.ContainsKey(rolled[di]))
                            {
                                if (game.runTimeManager[rolled[di]] == 0)
                                {
                                    game.numberOfDice -= 1;
                                    game.UpdateCard(rolled[di]);
                                    rolled.RemoveAt(di);
                                }
                            }
                        }
                        // If Player Got 4, 5, 6
                        Console.WriteLine(game.ReturnCard());
                        int sum = 0;
                        foreach (int key in game.runTimeManager.Keys)
                        {
                            sum += game.runTimeManager[key];
                        }
                        if (sum == 3)
                        {
                            // The player is currently scoring.. nice
                            int score = 0;
                            foreach (int di in rolled)
                            {
                                // Add up remainging dice as score for player
                                score += di;
                            }
                            // Update The Players Score
                            game.UpdateScore(player, score);
                            // Tell the player how many oints they just scored
                            Console.WriteLine("Plus: " + score.ToString() + " points!!!");
                        }
                        // Determine of points aquired for each roll
                        game.numberOfTurns -= 1;
                    } // while (game.numberOfTurns > 0)
                    DisplayPlayersCurrentsScores(game.ReturnScore());
                    // Reset next player
                    game.clearStats();
                }
                // We want to see whats on the console for debugging
                // The game is over print the final scores
                DisplayPlayersCurrentsScores(game.ReturnScore());
                // Use the final scores to determine WON
                if (game.playerOneScore > game.playerTwoScore)
                {
                    Console.WriteLine("PLAYER... ONE... IS... THE WINNER");
                }
                else if (game.playerTwoScore > game.playerOneScore)
                {
                    Console.WriteLine("PLAYER...TWO... IS... THE WINNER");
                }
                else
                {
                    Console.WriteLine("THE GAME IS A DRAW");
                }
                // Determine If They Want To Play Again
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Type 'Y' for Yes, hit 'Enter' for No.");
                Console.Write(":");
                string userInput = Console.ReadLine();
                // Validatating Input
                if (!string.Equals(userInput.Trim().ToUpper(), "Y"))
                {
                    playAgain = false;
                }
            }
            Console.WriteLine("GAME OVER");
            Console.WriteLine("PRESS ENTER TO EXIT GAME");
            Console.ReadKey();
        }
        static void DisplayWhosTurnItIs(int player)
        {
            Console.WriteLine("It is player " + player.ToString() + "'s turn;");
        }
        static void DisplayRemainingTurns(int remainingRolls)
        {
            Console.WriteLine("You have " + remainingRolls.ToString() + " remaining rolls.");
            Console.WriteLine("Press enter to 'Roll' your dice...");
        }
        static void DisplayDiceRolled(List<int> diceRolled)
        {
            Console.WriteLine("You rolled:");
            string print_dice = string.Empty;
            // Iterate the device
            // Print message to console
            foreach (int di in diceRolled)
            {
                if (diceRolled.IndexOf(di) == diceRolled.Count - 1)
                {
                    print_dice += di.ToString();
                }
                else
                {
                    print_dice += di.ToString() + " ,  ";
                }
            }
            Console.WriteLine(print_dice);
        }
        static void DisplayPlayersCurrentsScores(string Score)
        {
            Console.WriteLine("Current Scoreboard:");
            Console.WriteLine(Score);
        }
    }
}

