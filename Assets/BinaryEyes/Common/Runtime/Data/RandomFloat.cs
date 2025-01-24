using System;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// Allows users to easily generate a random floating-point value from a
    /// given base and modifier by an interval.
    /// </summary>
    [Serializable]
    public struct RandomFloat
    {
        public float Base;
        public Interval Mod;
        public float Get() => Base + Mod.GetRandom();

        public RandomFloat(float mod)
            : this(0.0f, new Interval(-mod, +mod))
        {

        }

        public RandomFloat(float baseValue, float mod)
            : this(baseValue, new Interval(-mod, +mod))
        {

        }

        public RandomFloat(float baseValue, float min, float max)
            : this(baseValue, new Interval(min, max))
        {

        }

        public RandomFloat(float baseValue, Interval mod)
        {
            Base = baseValue;
            Mod = mod;
        }
    }
}