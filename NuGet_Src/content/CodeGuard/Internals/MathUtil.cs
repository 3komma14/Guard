using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace $rootnamespace$.CodeGuard.Internals
{
    public class MathUtil
    {
        public static bool IsOdd(int value)
        {
            return ((value & 1) == 1);
        }

        public static bool IsOdd(long value)
        {
            return ((value & 1) == 1);
        }

        public static bool IsEven(int value)
        {
            return ((value & 1) == 0);
        }

        public static bool IsEven(long value)
        {
            return ((value & 1) == 0);
        }

        public static bool IsPrime(int value)
        {
            return IsPrime((long)value);
        }

        public static bool IsPrime(long value)
        {
            // Throw out impossibles
            if (value < 2)
            {
                return false;
            }

            // Don't need to test above the square root of a number
            var squareRootOfValue = (int)Math.Sqrt(value);
            for (var i = 2; i <= squareRootOfValue; i++)
            {
                // If remainder is 0, number is not prime
                if (value % i == 0)
                {
                    // return false
                    return false;
                }
            }

            // If all conditions are met, return true
            return true;
        }

    }
}
