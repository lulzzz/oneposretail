using System;
using System.Collections.Generic;
using System.Linq;

namespace OnePos.Framework.DynamicLinq
{
    internal class Signature : IEquatable<Signature>
    {
        public readonly int PropertyHashCode;
        public DynamicProperty[] Properties;

        public Signature(IEnumerable<DynamicProperty> properties)
        {
            DynamicProperty[] dynamicProperties = properties as DynamicProperty[] ?? properties.ToArray();
            Properties = dynamicProperties.ToArray();
            PropertyHashCode = 0;
            foreach (DynamicProperty p in dynamicProperties)
            {
                PropertyHashCode ^= p.Name.GetHashCode() ^ p.Type.GetHashCode();
            }
        }

        #region IEquatable<Signature> Members

        public bool Equals(Signature other)
        {
            if (Properties.Length != other.Properties.Length) return false;
            return !Properties
                        .Where((t, i) => t.Name != other.Properties[i].Name || t.Type != other.Properties[i].Type)
                        .Any();
        }

        #endregion

        public override int GetHashCode()
        {
            return PropertyHashCode;
        }

        public override bool Equals(object obj)
        {
            return obj is Signature && Equals((Signature) obj);
        }
    }
}