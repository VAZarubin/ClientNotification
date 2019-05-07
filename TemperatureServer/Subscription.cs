using System;

namespace TemperatureServer
{
    public class Subscription : IEquatable<Subscription>
    {
        #region Properties

        public string IpAddress { get; set; }

        #endregion

        #region Operators

        public static bool operator ==(Subscription left, Subscription right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Subscription left, Subscription right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Subscription)obj);
        }

        public override int GetHashCode()
        {
            return IpAddress != null ? IpAddress.GetHashCode() : 0;
        }

        #endregion

        #region IEquatable<Subscription> Members

        public bool Equals(Subscription other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(IpAddress, other.IpAddress);
        }

        #endregion
    }
}
