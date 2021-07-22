using System;
using System.Collections.Generic;
using System.Text;

namespace rational_class
{
    class Rational //TODO, this doesn't work yet
    {
        bool positive;
        Factorized numerator;
        Factorized denominator;
        bool isZero;

        public Rational(ulong numerator, ulong denominator, bool pos)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            if (numerator == 0)
            {
                isZero = true;
                this.numerator = new Factorized(1);
                this.denominator = new Factorized(1); //I'm afraid if I don't do this, the thing will shit itself later
            }
            else
            {
                isZero = false;
                positive = pos;
                this.numerator = new Factorized(numerator);
                this.denominator = new Factorized(denominator);
            }
            this.Simplify();
        }

        public Rational(long numerator, long denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException();
            }
            if (numerator == 0)
            {
                isZero = true;
                this.numerator = new Factorized(1);
                this.denominator = new Factorized(1); //I'm afraid if I don't do this, the thing will shit itself later
            }
            else
            {
                isZero = false;
                positive = (numerator > 0 ^ denominator > 0);
                this.numerator = new Factorized((ulong)Math.Abs(numerator));
                this.denominator = new Factorized((ulong)Math.Abs(denominator));
            }
            this.Simplify();
        }
        private Rational(Factorized numerator, Factorized denominator, bool positive)
        {
            isZero = false;
            this.positive = positive;
            this.numerator = new Factorized(numerator);
            this.denominator = new Factorized(denominator);
            this.Simplify();
        
        }

        public void WriteWeirdRational()
        {
            Console.WriteLine("Numerator: ");
            numerator.WriteFactors();
            Console.WriteLine("Denominator: ");
            denominator.WriteFactors();
            Console.WriteLine("Positive: " + positive);
            //I'll write a better function to write these.

        }

        private void Simplify()
        {
            Factorized toDivideBy = Factorized.HCF(numerator, denominator);
            numerator = Factorized.UnsafeDivide(numerator, toDivideBy);
            denominator = Factorized.UnsafeDivide(denominator, toDivideBy);
        }

        public static Rational operator *(Rational a, Rational b)
            {
            Factorized newNumerator = a.numerator * b.numerator;
            Factorized newDenominator = a.denominator * b.denominator;
            Rational c = new Rational(newNumerator, newDenominator, !(a.positive^b.positive));
            c.Simplify();
            return c;

            }

    }

}
