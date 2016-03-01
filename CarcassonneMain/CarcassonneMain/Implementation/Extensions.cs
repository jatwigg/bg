using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarcassonneMain.Implementation
{
    internal static class Extensions
    {
        private static Random _random = new Random();
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items)
		{
			// shuffle stuff
			return items.OrderBy(i => _random.NextDouble());
		}
    }
}
