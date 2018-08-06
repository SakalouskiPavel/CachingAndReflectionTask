using System.Collections.Generic;
using System.Reflection;

namespace Task1
{
    public class CustomGenericComparer<T> : IEqualityComparer<T> 
        where T: class 
    {
        public bool Equals(T x, T y)
        {
            return Equals((object)x, (object)y);
        }

        public int GetHashCode(T obj)
        {
            throw new System.NotImplementedException();
        }

        private new bool Equals(object x, object y)
        {
            if ((x == null) || (y == null))
            {
                return false;
            }
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            var props = x.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType.IsValueType)
                {
                    if (!prop.GetValue(x).Equals(prop.GetValue(y)))
                    {
                        return false;
                    }
                }
                else if (!Equals(prop.GetValue(x), prop.GetValue(y)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}