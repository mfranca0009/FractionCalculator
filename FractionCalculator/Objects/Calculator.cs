/************************************************************
 *                                                          *
 *  Author:        Matthew Franca                           *
 *  Course:        C# Programming                           *
 *  File:          Calculator.cs                            *
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

namespace FractionCalculator.Objects
{
    class Calculator
    {
        public Calculator() { }

        public Fraction Add(Fraction a, Fraction b)
        {
            int numerator = 0;
            int denominator = 0;

            Fraction newFraction = new Fraction(numerator, denominator);

            if (a.GetDenominator() == b.GetDenominator())
            {

                newFraction.SetNumerator(a.GetNumerator() + b.GetNumerator());

                newFraction.SetDenominator(b.GetDenominator());

            }
            else if (a.GetDenominator() != b.GetDenominator())
            {

                int temp = a.GetDenominator();


                a.SetDenominator(a.GetDenominator() * b.GetDenominator());
                a.SetNumerator(a.GetNumerator() * b.GetDenominator());

                b.SetDenominator(b.GetDenominator() * temp);
                b.SetNumerator(b.GetNumerator() * temp);

                newFraction.SetNumerator(a.GetNumerator() + b.GetNumerator());
                newFraction.SetDenominator(a.GetDenominator());

            }

            return Simplify(newFraction);
        }

        public Fraction Multiply(Fraction a, Fraction b)
        {
            int numerator = 0;
            int denominator = 0;

            Fraction productFraction = new Fraction(numerator, denominator);

            productFraction.SetNumerator(a.GetNumerator() * b.GetNumerator());
            productFraction.SetDenominator(a.GetDenominator() * b.GetDenominator());

            return Simplify(productFraction);
        }

        public Fraction Simplify(Fraction f)
        {

            int a = f.GetDenominator();
            int b = f.GetNumerator();
            int temp;
            int remainder;

            if (b > a)
            {

                temp = a;
                a = b;
                b = temp;
            }

            while (b > 0)
            {

                remainder = a % b;
                a = b;
                b = remainder;
            }


            if (a != 0)
            {

                f.SetDenominator(f.GetDenominator() / a);
                f.SetNumerator(f.GetNumerator() / a);

            }


            return f;
        }
    }
}
