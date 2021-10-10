/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          InputManager.cs                          *
 *                                                          *
 *  Description:   Fraction Calculator for adding,          *
 *                 multiplying, and simplifying fractions.  *
 *                 Also provides conversion from fraction   *
 *                 to decimal.                              *
 *                                                          *
 *  Input:         User input to retrieve action the user   *
 *                 wants to execute, and the fraction(s)    *
 *                 they would like to input for calculation *
 *                 or conversion.                           *
 *                                                          *
 *  Output:        Depending on the user's action, it will  *
 *                 output either the sum of the fractions,  *
 *                 product of the fractions, decimal        *
 *                 representation of the fraction, or       *
 *                 simplified fraction.                     *
 *                                                          *
 ************************************************************/

using System;
using FractionCalculator.Objects;

namespace FractionCalculator.Managers
{
    class InputManager
    {
        public InputManager() { }

        public Fraction RetrieveFractionInput(int numberCount, string task)
        {
            Fraction fraction = new Fraction(0, 0);

            while (fraction.GetNumerator() == 0 && fraction.GetDenominator() == 0)
            {
                switch (task)
                {
                    case "MultipleAllowed":
                        {
                            Console.Write($"Enter fraction #{numberCount} ( #/# ): ");
                            break;
                        }
                    case "OneOnly":
                        {
                            Console.Write("\nEnter fraction ( #/# ): ");
                            break;
                        }
                }

                fraction = ParseFraction();
            }

            return fraction;
        }

        public int RetrieveIntInput(string task)
        {
            int value = -1;

            while (value == -1)
            {
                switch (task)
                {
                    case "Action":
                        {
                            Console.Write("Enter Action: ");
                            break;
                        }
                    case "FractionCountToAdd":
                        {
                            Console.Write("\nHow many fractions to add?: ");
                            break;
                        }
                    case "FractionCountToMultiply":
                        {
                            Console.Write("\nHow many fractions to multiply?: ");
                            break;
                        }
                }

                value = ParseInt(task);
            }

            return value;
        }

        public char RetrieveCharInput()
        {
            char runInput = 'a';

            while (runInput != 'y' && runInput != 'n')
            {
                Console.Write("Would you like to continue?(y\\n): ");
                runInput = ParseChar();
            }

            return runInput;
        }

        private char ParseChar()
        {
            char runInput = 'a';

            try
            {
                runInput = Convert.ToChar(Console.ReadLine());
            }
            catch (Exception)
            {
                // Catch exception if the character passed is in an incorrect format to convert or empty
                Console.WriteLine("Invalid input! Try again.\n");
                return 'a'; // error character, re-loop input
            }

            // Make character into lowercase (in case Y or N was used)
            runInput = Char.ToLower(runInput);

            // input must be 'y' or 'n', if not then prompt input again.
            if (runInput != 'y' && runInput != 'n')
            {
                Console.WriteLine("Must be [y/Y] or [n/N]! Try again.\n");
                return 'a'; // error character, re-loop input
            }

            return runInput;
        }

        private int ParseInt(string task)
        {
            int value = -1;

            // Try to retrieve user input
            try
            {
                value = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                // Catch exception if the value passed is in an incorrect format to convert or empty
                Console.WriteLine("Incorrect input! Try again.\n");
                return -1; // error code, re-loop input
            }

            switch (task)
            {
                case "Action":
                    {
                        // Cannot be less than 1 or greater than 5
                        if (value < 1 || value > 5)
                        {
                            Console.WriteLine("Wrong action! Try again.\n");
                            return -1; // error code, re-loop input
                        }
                        break;
                    }
                case "FractionCountToAdd":
                case "FractionCountToMultiply":
                    {
                        if (value <= 1)
                        {
                            Console.WriteLine("Must be at least two fractions! Try again.\n");
                            return -1; // error code, re-loop input
                        }
                        break;
                    }
            }

            return value;
        }

        private Fraction ParseFraction()
        {
            Fraction fraction = new Fraction(0, 0);

            // Try to retrieve user input
            try
            {
                string fractionString = Convert.ToString(Console.ReadLine());

                string[] fractionParts = fractionString.Split('/');
                int numerator = Convert.ToInt32(fractionParts[0]);
                int denominator = Convert.ToInt32(fractionParts[1]);

                fraction.SetNumerator(numerator);
                fraction.SetDenominator(denominator);
            }
            catch (Exception)
            {
                // Catch exception if the value passed is in an incorrect format to convert or empty
                Console.WriteLine("Incorrect input! Try again.\n");

                // Make sure we are passing a 0/0 fraction as an error code to re-loop input
                fraction.SetNumerator(0);
                fraction.SetDenominator(0);

                return fraction;
            }

            if (fraction.GetNumerator() < 0 || fraction.GetDenominator() <= 0)
            {
                // Prompt reason of failure
                Console.WriteLine("The denominator cannot be 0, and the numerator must be at least 0 or greater! Try again.\n");

                // Make sure we are passing a 0/0 fraction as an error code to re-loop input
                fraction.SetNumerator(0);
                fraction.SetDenominator(0);

                return fraction;
            }

            return fraction;
        }
    }
}
