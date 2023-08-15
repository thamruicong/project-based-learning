using System;

namespace Engine
{
    internal class RandomNumberGenerator
    {
        private static Random _generator = new();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _generator.Next(minimumValue, maximumValue + 1);
        }
    }
}