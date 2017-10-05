using System;
using System.Threading;

namespace EarthdawnGamemasterAssistant.CharacterGenerator.Dice
{
    public static class StaticRandom
    {
        private static int seed;

        private static readonly ThreadLocal<Random> ThreadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance => ThreadLocal.Value;
    }
}