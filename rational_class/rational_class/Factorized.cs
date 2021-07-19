using System;
using System.Collections.Generic;
using System.Text;

namespace rational_class
{
    class ResultOutOfRangeException : Exception
    { }
    class Factorized //represents a positive whole number using its prime factors.
    {
        Dictionary<ulong, ulong> factors; //key for prime, value for the power.
        
        //CONSTRUCTORS
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

        
        //WRTITING IT OUT
        public void WriteFactors()
        {
            foreach (var factor in factors)
            {
                Console.WriteLine(factor.Key + " " + factor.Value);
            }
        }
        public long ToLong()
        {
            long i = 1;
            foreach (var prime in factors)
            {
                i *= (long)(Math.Pow(prime.Key, prime.Value));
            }
            return i;
        }

        //OPERATORS 
        public static Factorized operator *(Factorized a, Factorized b)
        {
            Factorized c = new Factorized(a);
            foreach (var factor in b.factors)
            {
                if (c.factors.ContainsKey(factor.Key))
                {
                    c.factors[factor.Key] = c.factors[factor.Key] + factor.Value;
                }
                else
                {
                    c.factors.Add(factor);
                }
            }
            return c;

        }
        public static Factorized operator /(Factorized a, Factorized b)
        //will break entire program if a%b!=1
        {
            Factorized c = new Factorized(a);
            foreach (var factor in b.factors)
            {
                if (c.factors.ContainsKey(factor.Key))
                {
                    c.factors[factor.Key] = c.factors[factor.Key] - factor.Value;
                }
                else
                {
                    throw new ResultOutOfRangeException();

                }
            }
            return c;

        }


        //SPECIFIC 
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
        public static Factorized UnsafeDivide(Factorized a, Factorized b)
            //will return wrong result if a%b!=1
        {
            Factorized c = new Factorized(a);
            foreach (var factor in b.factors)
            {
                
                    c.factors[factor.Key] = c.factors[factor.Key] - factor.Value;
                if (c.factors[factor.Key]==0)
                { c.factors.Remove(factor.Key); }
                
            }
            return c;


        }


    }

}
