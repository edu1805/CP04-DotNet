using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public sealed class LicensePlate
    {
        public string Value { get; }

        public LicensePlate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("License plate is required", nameof(value));

            if (value.Length < 6 || value.Length > 10)
                throw new ArgumentException("License plate length invalid", nameof(value));

            Value = value.ToUpperInvariant();
        }

        public override string ToString() => Value;

        public override bool Equals(object? obj)
        {
            if (obj is not LicensePlate other) return false;
            return Value == other.Value;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(LicensePlate left, LicensePlate right) =>
            Equals(left, right);

        public static bool operator !=(LicensePlate left, LicensePlate right) =>
            !Equals(left, right);
    }
}
