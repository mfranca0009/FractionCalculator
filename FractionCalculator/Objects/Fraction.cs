/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Fraction.cs                              *
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

namespace FractionCalculator.Objects
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator, int denominator)
        {

            this.numerator = numerator;
            this.denominator = denominator;

        }

        public double ToDecimal()
        {

            double decimalForm = (double)this.numerator / (double)this.denominator;

            return decimalForm;
        }

        public static void DisplayFraction(Fraction f)
        {

            Console.Write($"{f.GetNumerator()}/{f.GetDenominator()}");

        }

        public int GetNumerator()
        {
            return numerator;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public void SetNumerator(int newVal)
        {
            numerator = newVal;
        }

        public void SetDenominator(int newVal)
        {
            denominator = newVal;
        }
    }
}
