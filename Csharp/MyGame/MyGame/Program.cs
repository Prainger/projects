using System;

namespace MyGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Library lib = new Library();
            
            Console.WriteLine("Player 1 can choose hero: ");
            Hero hero1 = lib.ChooseHero();
            
            Console.WriteLine("to play singleplayer 's' and to play multiplayer 'm' ");
            string myInput = "Wrong input";
            while (!(myInput == "s" || myInput == "S" || myInput == "m" || myInput == "M"))
            {
                myInput = Console.ReadLine();
            }
            bool computer = myInput == "s" || myInput == "S";
            
            Hero hero2 = hero1;
            while (hero1 == hero2)
            {
                hero2 = lib.ComputerChooseHero();

                if (!computer)
                {
                    Console.WriteLine("Player 2 can choose hero: ");
                    hero2 = lib.ChooseHero();
                }
            }
            
            Arena arena = new Arena(hero1, hero2, computer);
            // Game
            //bool playAgain = true;
            //while (playAgain)
            //{
                while (!arena.IsGameOver())
                {
                    arena.PerformRound();

                }
                arena.PrintResult();
                arena.RestartMatch();
                
                //playAgain = PlayAgain(); 
            //}
        }
/*
        private static bool PlayAgain()
        {
            Console.WriteLine("If you wanna play again type 'y' ");
            string nextRound = null;
            while (nextRound == null)
            {
                nextRound = Console.ReadLine();
            }
            return (nextRound == "y" || nextRound == "Y");
        
        }*/
    }
}