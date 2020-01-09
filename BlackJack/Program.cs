using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the Grand Hotel and Casino.  What should I call you?");
            string playerName = Console.ReadLine();
            
            Console.WriteLine("How much money did you bring with you today?");
            int bank = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Hello {0}, would you like to start our blackjack game?", playerName);
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya" || answer == "sure")
            {
                Player player = new Player(playerName, bank);          //create new player object and initialize him with his name/how much he bought (through a constructor)
                Game game = new TwentyOneGame();                       //created player, now we should create a game.  (using polymorphism) 
                game += player;                                        //adding player to the game
                player.isActivelyPlaying = true;                       //while the player is actively playing, continue playing the game.  Now we have a way to see if player wants to play
                
                while (player.isActivelyPlaying && player.Balance > 0) //checks: does the player want to keep playing, and does he have enough money to play
                {
                    game.Play();
                }
                
                game -= player;
                Console.WriteLine("Thank You For Playing!");
            }
           
            Console.WriteLine("Feel free to look around the casino, Goodbye for now.");
            Console.ReadLine();
        }
    }
}
