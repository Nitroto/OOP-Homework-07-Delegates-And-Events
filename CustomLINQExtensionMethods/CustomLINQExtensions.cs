using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomLINQExtensionMethods
{

    public static class CustomLINQExtensions
    {
        public static IEnumerable<T> WhereNot<T>(
            this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection", "Collection is empty.");
            }
            var matches = new List<T>();
            foreach (var element in collection)
            {
                if (!predicate(element))
                {
                    matches.Add(element);
                }
            }
            return matches;
        }

        public static TSelector Max<TSource, TSelector>(
            this IEnumerable<TSource> collection, Func<TSource, TSelector> selector)
        {
            if (!collection.Any())
            {
                throw new ArgumentNullException("collection","Collection is empty.");
            }
            var comparer = Comparer<TSelector>.Default;
            TSelector maxValue = selector(collection.First());
            foreach (TSource item in collection.Skip(1))
            {
                TSelector value = selector(item);
                if (comparer.Compare(value, maxValue) > 0)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }
    }
}
