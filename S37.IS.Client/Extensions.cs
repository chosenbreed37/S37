using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S37.IS.Client
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> source,  Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
}
