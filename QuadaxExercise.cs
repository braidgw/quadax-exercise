using System;

namespace test
{
    class QuadaxExercise
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string masterLine = "";
            int numberOfGuesses = 0;

            // generate the masterLine
             for (int i = 0; i<4; i++) 
            {
                int randomNum = rand.Next(1,7);
                masterLine += randomNum + "";
            }
           
           bool isCorrect = false;

            // logic for game
           for(; numberOfGuesses < 10; numberOfGuesses++)
           {
               bool isProperNum = false;
               string input = "";

                // make sure our input is a valid guess
                // - all numbers
                // - length of 4
                // - between 1 and 6
               while (isProperNum == false)
               {
                   try {
                       isProperNum = true;
                       Console.WriteLine("Please enter a valid guess attempt # " + (numberOfGuesses +1) + ": ");
                       input = Console.ReadLine();
                       int test = Int32.Parse(input);
                       if (input.Length != 4) 
                       {
                           Console.WriteLine("Please write a number length 4");
                           isProperNum = false;
                       } else {
                           for (int i = 0; i < 4; i++)
                           {
                               int holder = Int32.Parse(input[i] + "");
                               if (holder > 6 || holder < 1)
                               {
                                   
                                   isProperNum = false;
                               }

                           }
                       }
                   } catch (FormatException) {
                       isProperNum = false;
                       Console.WriteLine("Please enter a number");
                   }
               }

                // determine is guess is correct or not
               isCorrect = guessTheKey(masterLine,input);
               if (isCorrect) {
                   Console.WriteLine("Hooray you won in " + (numberOfGuesses + 1) + " guesses");
                   break;
               }
           }
           if (!isCorrect)
           {
               Console.WriteLine("Sorry the correct answer was: " + masterLine);
           }
            
        }
        
        public static bool guessTheKey(string masterLine, string guess) {
            // logic for displaying the correct guesses
            for (int i = 0; i < 4; i++)
            {
                if (masterLine[i]==guess[i])
                {
                    Console.Write("+,");
                } else if (masterLine.Contains(guess[i]+""))
                {
                    Console.Write("-,");
                } else {
                    Console.Write(" ,");
                }
            }
            Console.WriteLine();
            if (guess.Equals(masterLine)) {
                return true;
            }
            return false;
        }
    }
}
