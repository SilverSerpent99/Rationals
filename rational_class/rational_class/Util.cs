using System;
using System.Collections.Generic;
using System.Text;

namespace rational_class
{
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

}
