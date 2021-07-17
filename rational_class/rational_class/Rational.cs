﻿using System;
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
                positive = (numerator > 0 && denominator > 0) || (numerator < 0 && denominator < 0);
                //would this be better with ifs? idk notify me if you have insight on that
                this.numerator = new Factorized((ulong)Math.Abs(numerator));
                this.denominator = new Factorized((ulong)Math.Abs(denominator));
            }
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

    }

}