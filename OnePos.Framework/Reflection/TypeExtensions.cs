using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnePos.Framework.Reflection
{
    /// <summary>
    /// Useful extension methods for Type
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Limits to all types that Derive from the specified type
        /// </summary>
        /// <param name="types"></param>
        /// <param name="derivedFromType"></param>
        /// <returns></returns>
        public static IEnumerable<Type> DerivedFrom(this IEnumerable<Type> types, Type derivedFromType)
        {
            return types.Where(a => a.IsDerivedFrom(derivedFromType));
        }
        /// <summary>
        /// Limit to all tpes that start with the spcified namespace
        /// </summary>
        /// <param name="types"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public static IEnumerable<Type> FromNamespace(this IEnumerable<Type> types, string nameSpace)
        {
            return types.Where(a => a.Namespace != null && a.Namespace.StartsWith(nameSpace));
        }
        /// <summary>
        /// Check if the Type has the specified custom attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attribute)
        {
            return type.HasAttribute(attribute, true);
        }
        /// <summary>
        ///  Check if the Type has the specified custom attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attribute"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attribute, bool inherit)
        {
            bool baseClass = type.GetCustomAttributes(attribute,inherit).Length>0;
            if (!inherit || baseClass)
                return baseClass;
            foreach (var inter in type.GetInterfaces())
            {
                if (inter.GetCustomAttributes(attribute, true).Length > 0)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Check if the Type is a SubClass of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSubclassOf<T>(this Type type)
        {
            return type.IsSubclassOf(typeof (T));
        }
        /// <summary>
        /// Check if the Type implements the interface 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        public static bool DoesImplement(this Type type, Type inter)
        {
            if (IsEquivalentTo(type, inter))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (IsEquivalentTo(i, inter))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the Type is Derived from another
        /// ie IList<> is derived from IList<>, is true
        /// ie IList<string> is derived from IList<>, is true
        /// ie IList<> implements IList<string>, is false
        /// ie IDo<string> implements IDo<int>, is false
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inter"></param>
        /// <returns></returns>
        public static bool IsDerivedFrom(this Type type, Type inter)
        {
            if (type.IsSubclassOf(inter))
                return true;
            if (IsDerivedFromImp(type, inter))
                return true;
            foreach (var i in type.GetInterfaces())
            {
                if (IsDerivedFromImp(i, inter))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// A type A is equivalent to B if 
        /// 1. They are they same type, AND
        /// 2. Their generic arguments match
        /// </summary>
        /// <param name="iLhs"></param>
        /// <param name="iRhs"></param>
        /// <returns></returns>
        private static bool IsDerivedFromImp(Type iLhs, Type iRhs)
        {
            if (iLhs == iRhs)
            {
                return true;
            }
            if (iLhs.IsGenericType && iRhs.IsGenericType)
            {
                iRhs.GetGenericArguments();
                if (iLhs.GetGenericTypeDefinition() != iRhs.GetGenericTypeDefinition())
                {
                    return false;
                }
                // Generic arguments must be match
                var lhsArgs = iLhs.GetGenericArguments();
                var rhsArgs = iRhs.GetGenericArguments();
                for (int x = 0; x < rhsArgs.Length; x++)
                {
                    // ie IList<> is derived from IList<>, is true
                    if (lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IList<string> is derived from IList<>, is true
                    if (!lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IList<> implements IList<string>, is false
                    if (lhsArgs[x].IsGenericParameter && !rhsArgs[x].IsGenericParameter)
                    {
                        return false;
                    }
                    // ie IDo<string> implements IDo<int>, is false
                    if (lhsArgs[x] != rhsArgs[x])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// A type A is equivalent to B if 
        /// 1. They are they same type, AND
        /// 2. Their generic arguments match
        /// </summary>
        /// <param name="iLhs"></param>
        /// <param name="iRhs"></param>
        /// <returns></returns>
        private static bool IsEquivalentTo(Type iLhs, Type iRhs)
        {
            if (iLhs == iRhs)
            {
                return true;
            }
            if (iLhs.IsGenericType && iRhs.IsGenericType)
            {
                iRhs.GetGenericArguments();
                if (iLhs.GetGenericTypeDefinition() != iRhs.GetGenericTypeDefinition())
                {
                    return false;
                }
                // Generic arguments must be match
                var lhsArgs = iLhs.GetGenericArguments();
                var rhsArgs = iRhs.GetGenericArguments();
                for (int x = 0; x < rhsArgs.Length; x++)
                {
                    // ie IList<> implements IList<>, is true
                    if (lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IList<string> implements IList<>, is false
                    if (!lhsArgs[x].IsGenericParameter && rhsArgs[x].IsGenericParameter)
                    {
                        return false;
                    }
                    // ie IList<> implements IList<string>, is true
                    if (lhsArgs[x].IsGenericParameter && !rhsArgs[x].IsGenericParameter)
                    {
                        continue;
                    }
                    // ie IDo<string> implements IDo<int>, is false
                    if (lhsArgs[x] != rhsArgs[x])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the Type implments the interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool DoesImplement<T>(this Type type)
        {
            return DoesImplement(type, typeof (T));
        }
        ///// <summary>
        ///// Gets the Code Style name of a Type. 
        ///// For Generics, it returns &lt; Type &gt;
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string GetCodeStyleName(this Type type)
        //{
        //    if (type.IsGenericParameter)
        //        return null;
        //    if (type.IsGenericType)
        //    {
        //        string args = type.GetGenericArguments().Select(a => GetCodeStyleName(a)).Join(",");
        //        string name = type.Name.Substring(0, type.Name.IndexOf("`"));
        //        return string.Format("{0}<{1}>", name, args);
        //    }
        //    return type.Name;
        //}
        ///// <summary>
        ///// Gets the Code Style Name, using fully qualified types. 
        ///// For Generics, it returns &lt; Type &gt;
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string GetQualifiedCodeStyleName(this Type type)
        //{
        //    if (type.IsGenericParameter)
        //        return null;
        //    if (type.IsGenericType)
        //    {
        //        string fullName = type.GetGenericTypeDefinition().FullName;
        //        string args = type.GetGenericArguments().Select(a => GetQualifiedCodeStyleName(a)).Join(",");
        //        string name = fullName.Substring(0, fullName.IndexOf("`"));
        //        return string.Format("{0}<{1}>", name, args);
        //    }
        //    return type.FullName;
        //}

        /// <summary>
        /// The type is in the same assembly as TWithType
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<Type> InAssemblyWith<TWithType>(this IEnumerable<Type> types)
        {
            return InAssemblyWith(types, typeof(TWithType));
        }
        /// <summary>
        ///The type is in the same assembly as inAssemblyWithType
        /// </summary>
        /// <param name="types"></param>
        /// <param name="inAssemblyWithType"></param>
        /// <returns></returns>
        public static IEnumerable<Type> InAssemblyWith(this IEnumerable<Type> types, Type inAssemblyWithType)
        {
            Assembly assm = inAssemblyWithType.Assembly;
            return types.Where(a => a.Assembly == assm);
        }
        /// <summary>
        /// A type has the attribute defined on it directly, or on one of its base types
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<Type> HasAttribute<TAttribue>(this IEnumerable<Type> types)
        {
            return HasAttribute(types, typeof(TAttribue));
        }
        /// <summary>
        /// A type has the attribute defined on it directly, or on one of its base types
        /// </summary>
        /// <param name="types"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static IEnumerable<Type> HasAttribute(this IEnumerable<Type> types, Type attributeType)
        {
            return types.Where(a => a.HasAttribute(attributeType));
        }
        ///// <summary>
        ///// Get a list of Custom Attributes.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="type"></param>
        ///// <param name="inherited"></param>
        ///// <returns>The Attributes, empty list of non</returns>
        //public static IEnumerable<T> GetCustomAttributes<T>(this Type type, bool inherited)
        //{
        //    return type.GetCustomAttributes(typeof (T), inherited).ToList<T>();
        //}
    }
}