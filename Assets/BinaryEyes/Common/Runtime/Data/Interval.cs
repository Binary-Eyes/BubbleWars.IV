using System;
using Random = UnityEngine.Random;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Interval structure describes a range of floating-point values.
    /// </summary>
    [Serializable]
    public struct Interval
    {
        public float Min;
        public float Max;
        public float Length => Max - Min;
        public readonly bool Contains(float value) => Min <= value && value <= Max;
        public readonly float GetRandom() => Random.Range(Min, Max);
        public readonly float GetLocked(float value) => Min > value ? Min : Max < value ? Max : value;

        public Interval(float value)
            : this(-value, +value)
        {

        }

        public Interval(float min, float max)
        {
            Min = min;
            Max = max;
        }

        public static Interval operator +(Interval lhs, Interval rhs) => new(lhs.Min + rhs.Min, lhs.Max + rhs.Max);
        public static Interval operator -(Interval lhs, Interval rhs) => new(lhs.Min - rhs.Min, lhs.Max - rhs.Max);
        public static Interval operator *(Interval lhs, Interval rhs) => new(lhs.Min * rhs.Min, lhs.Max * rhs.Max);
        public static Interval operator *(Interval lhs, float rhs) => new(lhs.Min*rhs, lhs.Max*rhs);
        public static Interval operator *(float lhs, Interval rhs) => new(lhs*rhs.Min, lhs*rhs.Max);
        public static Interval operator /(Interval lhs, Interval rhs) => new(lhs.Min/rhs.Min, lhs.Max/rhs.Max);
        public static Interval operator /(Interval lhs, float rhs) => new(lhs.Min/rhs, lhs.Max/rhs);
    }
}
