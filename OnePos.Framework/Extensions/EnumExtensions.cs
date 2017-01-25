using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace OnePos.Framework.Extensions
{
    /// <summary>
    /// Userful extensions for Enumerations
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the description specified in the DescriptionAttribute of the enum value, if one
        /// was specified. If no DescriptionAttribute could be found, the string representation
        /// of the enum value is returned. String.Empty is returned if the value is null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                return String.Empty;
            }

            FieldInfo fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

        public static string GetCategory(this Enum value)
        {
            if (value != null)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                var attributes = (CategoryAttribute[]) fi.GetCustomAttributes(typeof (CategoryAttribute), false);
                if (attributes.Length > 0)
                    return attributes[0].Category;
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts to an Enum or default value
        /// </summary>
        /// <typeparam name="TEnumTo"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static TEnumTo ToEnumOrDefault<TEnumTo>(this Object enumeration)
        {
            try
            {
                return enumeration.ToEnum<TEnumTo>();
            }
            catch (Exception)
            {
                return default(TEnumTo);
            }
        }

        /// <summary>
        /// Extracts a value from one enum and sets to another, on assumption that both enums have identical items.
        /// In DEBUG mode this will check that both enums have the same types and cause an exception if
        /// they dont.
        /// In RELEASE mode this will throw an exception if you try to map a value that doesn't exist.
        /// If you are converting to and from a Nullable type, make sure the to type is Nullable. Otherwise
        /// you will get an Exception when the value is null.
        /// </summary>
        /// <typeparam name="TEnumTo">Enum Type to set value to, required.</typeparam>
        /// <param name="enumeration">enum object to get value from, required.</param>
        /// <returns>Mapped value</returns>
        public static TEnumTo ToEnum<TEnumTo>(this Object enumeration) //where TEnumTo : struct 
        {
            Type toEnumType = typeof(TEnumTo);
            bool isToNullableType = IsNullableType(toEnumType);
            if (isToNullableType)
                toEnumType = toEnumType.GetGenericArguments()[0];
            Debug.Assert(enumeration == null || AssertToEnumContraints(enumeration.GetType(), toEnumType));
            var enumerationHasValue = enumeration != null && ((enumeration as string) != string.Empty);
            if (isToNullableType && !enumerationHasValue)
            {
                return default(TEnumTo);
            }
            if (!isToNullableType && !enumerationHasValue)
            {
                throw new ArgumentException(string.Format("Cannot map null value to type {0}. Use ToEnum<{0}?> instead.", typeof(TEnumTo).FullName));
            }
            if (enumeration is int && !Enum.IsDefined(toEnumType, enumeration))
            {
                throw new ArgumentException(string.Format("Cannot map value {0} to type {1}.The value does not exist as an Enum.", enumeration, typeof(TEnumTo).FullName));
            }
            try
            {
                if (enumeration is int)
                {
                    return (TEnumTo)enumeration;
                }
                return (TEnumTo)Enum.Parse(toEnumType, enumeration.ToString());
            }
            catch (Exception exp)
            {
                throw new ApplicationException(string.Format("ToEnum failed. Enum value {0}.{1} does not exist.", typeof(TEnumTo).FullName, enumeration), exp);
            }
        }

        /// <summary>
        /// If the parameter passed in is Nullable, the to type must also be nullable
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static bool AssertToEnumContraints(Type from, Type to)
        {
            if (from == typeof(string))
            {
                return true;
            }
            if (from.IsEnum)
            {
                AssertHaveSameValues(from, to);
            }
            if (from == typeof(int))
            {
                return true;
            }
            return true;
        }

        private static void AssertHaveSameValues(Type from, Type to)
        {
            string[] fromValues = Enum.GetNames(from);
            string[] toValues = Enum.GetNames(to);
            IEnumerable<string> e1 = fromValues.OrderBy(a => a);
            IEnumerable<string> e2 = toValues.OrderBy(a => a);
            var intersect = e1.Intersect(e2);
            var missingElements = e1.Except(intersect);
            var enumerable = missingElements as string[] ?? missingElements.ToArray();
            var failMessage = string.Format("Enum {0} must be a SubSet of {1}. You cannot use ToEnum for these. Also you should write a UnitTest to check this!. The missing elements are: {2}.", from.FullName, to.FullName, string.Join(", ", enumerable));
            if (enumerable.Count() != 0)
            {
                throw new ApplicationException(failMessage);
            }
        }

        private static bool IsNullableType(Type t)
        {
            return
                t.IsGenericType &&
                t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }

}
