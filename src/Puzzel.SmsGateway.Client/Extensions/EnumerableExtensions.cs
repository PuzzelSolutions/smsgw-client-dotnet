using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzel.SmsGateway.Client.Extensions
{
    public static class EnumerableExtensions
    {
        public static string Dump<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null
                ? string.Join(Environment.NewLine, enumerable.Select(t => t is not IEnumerable<T> en ? t?.ToString() : Dump(en)))
                : string.Empty;
        }
    }
}