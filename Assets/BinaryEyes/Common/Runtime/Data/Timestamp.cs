using System;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// The Timestamp container encapsulates a particular moment in time as
    /// a 64bit integer value representing the milliseconds elapsed from the
    /// Unix epoch and can be used to synchronize different events across
    /// different systems.
    /// </summary>
    [Serializable]
    public readonly struct Timestamp
        : IEquatable<Timestamp>, IComparable<Timestamp>
    {
        private readonly long _value;
        private Timestamp(long value) => _value = value;

        public static Timestamp Empty()
            => new(0);

        public static Timestamp New()
            => new(new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds());

        public override string ToString() => _value.ToString();
        public static long operator -(Timestamp lhs, Timestamp rhs) => lhs._value - rhs._value;
        public static explicit operator long(Timestamp value) => value._value;
        public static explicit operator Timestamp(long value) => new(value);

        public override int GetHashCode() => _value.GetHashCode();
        public override bool Equals(object other) => other is Timestamp timestamp && Equals(timestamp);
        public bool Equals(Timestamp other) => _value == other._value;
        public int CompareTo(Timestamp other) => _value.CompareTo(other._value);
        public static bool operator ==(Timestamp lhs, Timestamp rhs) => lhs._value == rhs._value;
        public static bool operator !=(Timestamp lhs, Timestamp rhs) => lhs._value != rhs._value;
        public static bool operator <(Timestamp lhs, Timestamp rhs) => lhs._value < rhs._value;
        public static bool operator <=(Timestamp lhs, Timestamp rhs) => lhs._value <= rhs._value;
        public static bool operator >(Timestamp lhs, Timestamp rhs) => lhs._value > rhs._value;
        public static bool operator >=(Timestamp lhs, Timestamp rhs) => lhs._value >= rhs._value;
    }
}
