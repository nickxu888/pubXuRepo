using System;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleMastermind
{
    class MastermindGame
    {
        const int MAX_INDIV_NUMBER = 6;
        const int MIN_INDIV_NUMBER = 1;
        const int MAX_DIGITS = 4;
        private ArrayList mastermap = null;
        private ArrayList workingmap = null;
        /// <summary>
        /// Generates a master code from 1111 to 6666
        /// </summary>
        /// <returns>An int from 1111 to 6666</returns>
        private int getMasterCode()
        {
            string strMasterdigit = "";
            String strMasterCode = "";
            mastermap = new ArrayList();
            Random rand = new Random();
            for (int i = 0; i < MAX_DIGITS; i++)
            {
                strMasterdigit = rand.Next(MIN_INDIV_NUMBER, MAX_INDIV_NUMBER).ToString();
                strMasterCode += strMasterdigit;
                GameRecord gr = new GameRecord()
                { digit = Convert.ToInt32(strMasterdigit),
                  position = i,
                  checkmark = "+"
                };
                mastermap.Add(gr);
            }
            return Convert.ToInt32(strMasterCode);
        }

      /// <summary>
      /// set a user input number into a working reord
      /// </summary>
      /// <param name="InputNum"></param>
        private void setWorkingGameRecord(string InputNum)
        {
           workingmap = new ArrayList();
           int iDigit = 0;
           for(int i=0;i< MAX_DIGITS; i++)
            {
                Char c = InputNum[i];
                iDigit = c - '0'; //convert char to int
                GameRecord gr = new GameRecord()
                {
                    digit = iDigit,
                    position = i,
                    checkmark = " "
                };
                workingmap.Add(gr);
            }
         }
        
        /// <summary>
        /// check if a working game record against a master is matched. 
        /// If both digit and position is matched, marked as +.
        /// If digit is matched but off the position, marked as -.
        /// If nothing is matched, marked as blank.
        /// </summary>
        private void checkGameRecord()
        {
            foreach (var mitem in mastermap)
            {
                GameRecord grm = (GameRecord)mitem;
                foreach (var witem in workingmap)
                {
                    GameRecord grw = (GameRecord)witem;
                    if (grw.digit == grm.digit && grm.position == grw.position)
                    {   
                        grw.checkmark = "+";
                     }
                    
                    if (grw.digit == grm.digit && grm.position != grw.position)
                    {
                        if (!grw.checkmark.Contains("+") && !grw.checkmark.Contains("-"))
                            grw.checkmark = "-";
                    }
                 }
            }
        }
        private void printGameResult()
        {
            StringBuilder result1 = new StringBuilder();
            StringBuilder result2 = new StringBuilder();
            StringBuilder result3 = new StringBuilder();
            StringBuilder result4 = new StringBuilder();
            StringBuilder result5 = new StringBuilder();
            StringBuilder result6 = new StringBuilder();
            foreach (var item in workingmap)
            {
                GameRecord grw = (GameRecord)item;
                result1.Append(grw.digit);
                result2.Append(grw.checkmark);
                result3.Append(grw.position);
            }
            foreach (var item in mastermap)
            {
                GameRecord grw = (GameRecord)item;
                result4.Append(grw.digit);
                result5.Append(grw.checkmark);
                result6.Append(grw.position);
            }
            Console.WriteLine("You entered {0}", result1.ToString());
            Console.WriteLine("My answer is {0}", result2.ToString());
            //Console.WriteLine("Master code is {0}", result4.ToString());
        }

        public bool ValidateInput(string sUserInput)
        {
            bool isValid = true;
            string fourDigitsPattern = @"^[1-6]{4}$";
            bool fourDigitsValid = Regex.IsMatch(sUserInput, fourDigitsPattern);
            if (sUserInput == null || !fourDigitsValid)
            {
                isValid = false;
            }
            return isValid;
        }

        public bool StartMastermind()
        {
            bool isSolved = false;
            int attemps = 1;
            int nMC = getMasterCode();
            string sUserInput = null;
            while (attemps <= 10)
            {
                Console.WriteLine("\nMake your guess(No.{0} guess):\n", attemps);
                sUserInput = Console.ReadLine();
                if (ValidateInput(sUserInput))
                {

                    if (Convert.ToInt32(sUserInput) == nMC)
                    {
                        Console.WriteLine("\nYou solved it!");
                        isSolved = true;
                        break;
                    }
                    else
                    {
                        setWorkingGameRecord(sUserInput);
                        checkGameRecord();
                        printGameResult();
                    }
                }
                else
                    Console.WriteLine("Please enter 4 digits only containing 1 to 6 and between 1111 and 6666.");
                attemps++;
            }
            
            return isSolved;
        }
    }
}
