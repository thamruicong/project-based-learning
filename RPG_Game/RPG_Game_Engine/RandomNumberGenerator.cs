using System;

namespace Engine
{
    internal class RandomNumberGenerator
    {
        private static Random _generator = new();

        public static int NumberBetweenInclusive(int minimumValue, int maximumValue)
        {
            return _generator.Next(minimumValue, maximumValue + 1);
        }

        public static int NumberBetweenInclusive(int maximumValue)
        {
            return _generator.Next(0, maximumValue + 1);
        }

        public static int NumberBetweenExclusive(int minimumValue, int maximumValue)
        {
            return _generator.Next(minimumValue, maximumValue);
        }

        public static int NumberBetweenExclusive(int maximumValue)
        {
            return _generator.Next(0, maximumValue);
        }
    }
}