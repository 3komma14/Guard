using System;

namespace BarsGroup.CodeGuard.Internals
{
    public class MathUtil
    {
        public static bool IsOdd(int value)
        {
            return (value & 1) == 1;
        }

        public static bool IsOdd(long value)
        {
            return (value & 1) == 1;
        }

        public static bool IsEven(int value)
        {
            return (value & 1) == 0;
        }

        public static bool IsEven(long value)
        {
            return (value & 1) == 0;
        }

        public static bool IsPrime(int value)
        {
            return IsPrime((long) value);
        }

        public static bool IsPrime(long value)
        {
            // Throw out impossibles
            if (value < 2)
                return false;

            // Don't need to test above the square root of a number
            var squareRootOfValue = (int) Math.Sqrt(value);
            for (var i = 2; i <= squareRootOfValue; i++)
                if (value % i == 0)
                    return false;

            // If all conditions are met, return true
            return true;
        }
    }
}