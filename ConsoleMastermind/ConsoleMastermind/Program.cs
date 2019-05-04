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
                int nMC = mg.getMasterCode();
                int attemps = 1;
                bool isLost = true;
                while (attemps <= 10)
                {
                    Console.WriteLine("\nMake your guess(No.{0} guess):\n", attemps);
                    sUserInput = Console.ReadLine();
                    if (!mg.ValidateInput(sUserInput))
                        Console.WriteLine("Please enter 4 digits only containing 1 to 6 and between 1111 and 6666.");
                    else
                    {
                        if (Convert.ToInt32(sUserInput) == nMC)
                        {
                            Console.WriteLine("\nYou solved it!");
                            isLost = false;
                            break;
                        }
                        else
                        {
                            mg.setWorkingGameRecord(sUserInput);
                            mg.checkGameRecord();
                            mg.printGameResult();
                        }
                    }
                    attemps++;
                }
                if (isLost)
                { Console.WriteLine("\nSorry, You have lost the game.\n");
                }
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

