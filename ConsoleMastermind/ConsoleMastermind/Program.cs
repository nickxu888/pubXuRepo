using System;

namespace ConsoleMastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlayagain = true;
            Console.WriteLine("\nMastermind Game\n");
            Console.WriteLine("You have 10 attemps to make a guess. Let's start to have a fun!");
            string sUserInput = null;
            while (isPlayagain)
            {
                MastermindGame mg = new MastermindGame();
                bool isLost = true;
                if(mg.StartMastermind())
                {
                    isLost = false;
                }
                if (isLost)
                  Console.WriteLine("\nSorry, You have lost the game.\n");
                Console.WriteLine("\nDo you want to play a game again? Enter Y/N\n");
                sUserInput = Console.ReadLine();
                if (sUserInput == null || sUserInput.Length==0 || sUserInput.ToUpper() == "Y" || sUserInput.ToUpper() == "YES")
                    isPlayagain = true;
                else
                    isPlayagain = false;
            }
            
        }
    }
}

