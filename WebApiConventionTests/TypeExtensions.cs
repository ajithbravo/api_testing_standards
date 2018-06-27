using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WebApiConventionTests
{
    public static class TypeExtensions
    {
        public static bool IsPrimitiveLike(this Type type)
        {
            return type.IsValueType || type == typeof(string);
        }

        public static IEnumerable<PropertyInfo> GetPublicProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToList();
        }

        public static bool IsComplexType(this Type type)
        {
            return !type.IsPrimitiveLike();
        }

        public static List<Type> GetNestedComplexTypes(this Type type)
        {
            var result = new List<Type>();

            var nonPrimitiveTypes = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.PropertyType)
                .Where(x => x.IsComplexType())
                .ToList();
            result.AddRange(nonPrimitiveTypes);

            foreach (var nonPrimitiveType in nonPrimitiveTypes)
            {
                var nestedNonPrimitiveTypes = GetNestedComplexTypes(nonPrimitiveType);
                result.AddRange(nestedNonPrimitiveTypes);
            }

            return result;
        }
    }
}