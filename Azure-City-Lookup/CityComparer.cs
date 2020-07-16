using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure_City_Lookup
{
    public class CityComparer : IEqualityComparer<City>
    {
        public bool Equals([AllowNull] City x, [AllowNull] City y)
        {
            return x.Country == y.Country &&
                   x.Name == y.Name;
        }
        public int GetHashCode([DisallowNull] City obj)
        {
            return obj.Country.GetHashCode() ^ obj.Name.GetHashCode();
        }
    }
}
