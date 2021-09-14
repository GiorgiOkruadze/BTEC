using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Extensions
{
    public static class ListExtensions
    {
        public static List<T> AddItemsInCollection<T>(this List<T> collection, int count)
        {
            for(var i = 0; i < count; i++)
            {
                collection.Add((T)Activator.CreateInstance(typeof(T)));
            }
            return collection;
        }
    }
}
