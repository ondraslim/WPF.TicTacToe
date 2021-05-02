using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TicTacToe.Common.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> FindAllImplementations<T>(this Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(typeof(T).IsAssignableFrom);
        }
    }
}