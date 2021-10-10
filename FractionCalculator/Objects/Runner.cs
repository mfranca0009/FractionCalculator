/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Runner.cs                                *
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
using System.Collections.Generic;
using FractionCalculator.Managers;

namespace FractionCalculator.Objects
{
    class Runner
    {
        private InputManager inputManager;
        public Runner() { inputManager = new InputManager(); }

        public void NoInputDriver(Calculator calc)
        {
            //fraction one to decimal value
            Fraction fractionOne = new Fraction(1, 2);

            //fraction two and three added
            Fraction fractionTwo = new Fraction(1, 7);
            Fraction fractionThree = new Fraction(1, 5);

            //fraction four, five, and six multiplied
            Fraction fractionFour = new Fraction(1, 4);
            Fraction fractionFive = new Fraction(2, 3);
            Fraction fractionSix = new Fraction(4, 5);

            //sum of fractions two and three
            Fraction sumFraction = new Fraction(0, 0);
            Fraction productFraction = new Fraction(0, 0);

            Console.WriteLine("\nMath With Fractions");
            Console.WriteLine("---------------------------\n");


            double fractionToDecimal = fractionOne.ToDecimal();

            Fraction.DisplayFraction(fractionOne); Console.Write(" = "); Console.WriteLine(fractionToDecimal + "\n");

            Fraction.DisplayFraction(fractionTwo); Console.Write(" + "); Fraction.DisplayFraction(fractionThree);

            sumFraction = calc.Add(fractionTwo, fractionThree);

            Console.Write(" = "); Fraction.DisplayFraction(sumFraction); Console.WriteLine("\n");

            Fraction.DisplayFraction(fractionFour); Console.Write(" X "); Fraction.DisplayFraction(fractionFive);
            Console.Write(" X "); Fraction.DisplayFraction(fractionSix);

            productFraction = calc.Multiply(fractionFour, fractionFive);
            productFraction = calc.Multiply(productFraction, fractionSix);

            Console.Write(" = "); Fraction.DisplayFraction(productFraction); Console.WriteLine("\n");

            Console.WriteLine("---------------------------\n");

            Console.WriteLine("Press any key to continue...");

            Console.ReadLine();
        }

        public void InputDriver(Calculator calc)
        {
            char runInput = 'y';

            while (runInput == 'y')
            {
                // Clear previous text and results, enhances readability if using program again.
                Console.Clear();

                Console.WriteLine("\nMath With Fractions");
                Console.WriteLine("---------------------------\n");

                Console.WriteLine("1. Add");
                Console.WriteLine("2. Multiply");
                Console.WriteLine("3. Fraction to Decimal");
                Console.WriteLine("4. Simplify");
                Console.WriteLine("5. Exit\n");

                int action = inputManager.RetrieveIntInput("Action");

                switch (action)
                {
                    case 1: // Add
                        {
                            int totalFractionsToAdd = inputManager.RetrieveIntInput("FractionCountToAdd");
                            List<Fraction> fractionList = new List<Fraction>();
                            Fraction resultFraction = new Fraction(0, 0);
                            Console.WriteLine();

                            // Retrieve fractions from user input
                            for (int i = 0; i < totalFractionsToAdd; i++)
                            {
                                fractionList.Add(inputManager.RetrieveFractionInput(i + 1, "MultipleAllowed"));
                            }

                            // If we only have 2 fractions, then simply add those together
                            if (fractionList.Count == 2)
                            {
                                resultFraction = calc.Add(fractionList[0], fractionList[1]);
                            }
                            else // More than 2, so retrieve the first out of the list, then iterate starting from the second in the list
                            {
                                resultFraction = fractionList[0];

                                for (int i = 1; i < fractionList.Count; i++)
                                {
                                    resultFraction = calc.Add(resultFraction, fractionList[i]);
                                }
                            }

                            // Display the result
                            Console.Write("\nResult: "); Fraction.DisplayFraction(resultFraction); Console.WriteLine("\n");
                            break;
                        }
                    case 2: // Multiply
                        {
                            int totalFractionsToAdd = inputManager.RetrieveIntInput("FractionCountToMultiply");
                            List<Fraction> fractionList = new List<Fraction>();
                            Fraction resultFraction = new Fraction(0, 0);
                            Console.WriteLine();

                            // Retrieve fractions from user input
                            for (int i = 0; i < totalFractionsToAdd; i++)
                            {
                                fractionList.Add(inputManager.RetrieveFractionInput(i + 1, "MultipleAllowed"));
                            }

                            // If we only have 2 fractions, then simply multiply those together
                            if (fractionList.Count == 2)
                            {
                                resultFraction = calc.Multiply(fractionList[0], fractionList[1]);
                            }
                            else // More than 2, so retrieve the first out of the list, then iterate starting from the second in the list
                            {
                                resultFraction = fractionList[0];

                                for (int i = 1; i < fractionList.Count; i++)
                                {
                                    resultFraction = calc.Multiply(resultFraction, fractionList[i]);
                                }
                            }

                            // Display the result
                            Console.Write("\nResult: "); Fraction.DisplayFraction(resultFraction); Console.WriteLine("\n");
                            break;
                        }
                    case 3: // Fraction to Decimal
                        {
                            // Retrieve user input and convert fraction to decimal representation
                            Fraction fraction = inputManager.RetrieveFractionInput(1, "OneOnly");
                            double result = fraction.ToDecimal();
                            Console.WriteLine();

                            // Display the result
                            Console.Write($"\nResult: {String.Format("{0:0.00##}", result)}"); Console.WriteLine("\n");
                            break;
                        }
                    case 4: // Simplify
                        {
                            // Retrieve user input and simplify fraction if possible
                            Fraction fraction = inputManager.RetrieveFractionInput(1, "OneOnly");
                            fraction = calc.Simplify(fraction);
                            Console.WriteLine();

                            Console.Write("\nResult: "); Fraction.DisplayFraction(fraction); Console.WriteLine("\n");
                            break;
                        }
                    case 5: // Exit
                        return;
                }

                runInput = inputManager.RetrieveCharInput();
            }
        }
    }
}
