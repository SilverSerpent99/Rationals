using System;
using System.Collections.Generic;

namespace rational_class
{

    //can i upload from Visual Studio
    //okay im trying again, failed the first time
    class Factorized //represents a positive whole number using its prime factors.
    {
        Dictionary<ulong, ulong> factors; //key for prime, value for the power.

        public long ToLong() 
        {
            long i = 1;
            foreach ( var prime in factors)
            {
                i *= (long)(Math.Pow(prime.Key, prime.Value));
            }
            return i;
        }



        public Factorized(Factorized prev)
        {

            this.factors = Util.CopyDictionary<ulong, ulong>(prev.factors);

        }
        public Factorized(ulong value)
        {
            ulong i = 2;
            factors = new Dictionary<ulong, ulong>();
            while (value > 1)
            {
                if (value % i == 0)
                {
                    this.factors.Add(i, 0);

                    do
                    {
                        this.factors[i]++;
                        value = value / i;


                    } while (value % i == 0);

                }
                i++;
            }
        }

        public void WriteFactors()
        {
            foreach (var factor in factors)
            {
                Console.WriteLine(factor.Key + " " + factor.Value);
            }
        }

        public static Factorized operator *(Factorized a, Factorized b)
        {
            Factorized c = new Factorized(a);
            foreach (var factor in b.factors)
            {
                if (c.factors.ContainsKey(factor.Key))
                {
                    c.factors[factor.Key] = c.factors[factor.Key]+factor.Value;
                }
                else
                {
                    c.factors.Add(factor);
                }
            }
            return c;

        }


        //the next two were written while I was tired, so they might have sneaky bugs
        public static Factorized HCF(Factorized a, Factorized b)
        {
            Factorized c = new Factorized(a);
            foreach (var factor in a.factors)
            {
                if (b.factors.ContainsKey(factor.Key))
                {
                    c.factors[factor.Key] = Math.Min(b.factors[factor.Key], factor.Value);
                }
                else
                {
                    c.factors.Remove(factor.Key);
                }
            }
            return c;

        }

        public static Factorized LCM(Factorized a, Factorized b)
        {
            Factorized c = new Factorized(a);
            foreach (var factor in b.factors)
            {
                if (c.factors.ContainsKey(factor.Key))
                {
                    c.factors[factor.Key] = Math.Max(c.factors[factor.Key], factor.Value);
                }
                else
                {
                    c.factors.Add(factor);
                }
            }
            return c;

        }

    }
    class Rational //TODO, this doesn't work yet
    {
        bool positive;
        Factorized numerator;
        Factorized denominator;
        bool isZero;

        public Rational(long numerator, long denominator) 
        {
            if (denominator==0)
            {
                throw new DivideByZeroException();
            }
            if (numerator==0)
            {
                isZero = true;
                this.numerator = new Factorized(1);
                this.denominator = new Factorized(1); //I'm afraid if I don't do this, the thing will shit itself later
            }else
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
    static class Util
    {

        //the "this" keyword here makes the "dictionary.Add(otherdictionary)"-like stuff possible
        //from ext source
        public static void Add<T, U>(this IDictionary<T, U> dic, KeyValuePair<T, U> KVP)
        {
            dic.Add(KVP.Key, KVP.Value);
        }
        public static bool IsPrime(int what) //not the best, but works
        {
            for (int i = 2; i < Math.Sqrt(what); i++)
            {
                if (what % i == 0)
                { return false; } //this is a bit ugly
            }
            return true;
        }

        public static void WritePrimeFactors(long what) //only works for positive.
        {
            Console.WriteLine("Prime Factoring " + what);
            long i = 2;
            while (what > 1)
            {
                while (what % i == 0)
                {
                    what = what / i;

                    Console.WriteLine(i);
                }
                i++;
            }

        }


        public static Dictionary<TKey, TValue> CopyDictionary<TKey, TValue>
   (Dictionary<TKey, TValue> original)
            //stolen and modified from StackOverflow
        {
            Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count,
                                                                    original.Comparer);
            foreach (KeyValuePair<TKey, TValue> entry in original)
            {
                ret.Add(entry.Key, entry.Value);
            }
            return ret;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Util.IsPrime(5119));
            //Util.WritePrimeFactors(1922);

            Factorized a = new Factorized(30720);

            Factorized b = new Factorized(1024);
            b = Factorized.LCM(a, b);

            Rational test = new Rational(-40, -12);

            test.WriteWeirdRational();

        }
    }
}
