using System;
using System.Collections.Generic;

namespace rational_class
{

    //can i upload from Visual Studio
    //okay im trying again, failed the first time
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
