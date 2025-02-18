using System.Numerics;

namespace _01.Extensions
{
    public static class IEnumerableExtension
    {
        public static T Sum<T>(this IEnumerable<T> collection)
            where T : INumber<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (!collection.Any())
            {
                return T.Zero;
            }

            T sum = T.Zero;
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }
        public static T Min<T>(this ICollection<T> collection)  where T :IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection.Count() == 0)
            {
                throw new InvalidOperationException("The collection is empty");
            }

            using(var enumerator = collection.GetEnumerator())
            {
                enumerator.MoveNext();
                T min = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.CompareTo(min) < 0)
                    {
                        min = enumerator.Current;
                    }
                }
                return min;
            }
        }
    }
}