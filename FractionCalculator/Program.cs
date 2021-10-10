/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Program.cs                               *
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

using FractionCalculator.Objects;

namespace FractionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner runner = new Runner();
            Calculator calculator = new Calculator();

            // Uncomment for a simple no-input test of the application.
            //runner.NoInputDriver(calcManager);

            // Run application driver for test with user interaction
            runner.InputDriver(calculator);
        }
    }
}
