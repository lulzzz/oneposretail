using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OnePos.Framework.ServiceModel
{
	public static class MessageKnownTypeProvider
	{
		private static List<Type> _knownTypes = new List<Type>();

		public static void ClearAllKnownTypes()
		{
			_knownTypes = new List<Type>();
		}

		public static void Register<T>()
		{
			Register(typeof(T));
		}

		public static void Register(Type type)
		{
			_knownTypes.Add(type);
		}

		public static void RegisterDerivedTypesOf<T>(Assembly assembly)
		{
			RegisterDerivedTypesOf(typeof(T), assembly.GetTypes());
		}

		public static void RegisterDerivedTypesOf<T>(IEnumerable<Type> types)
		{
			RegisterDerivedTypesOf(typeof(T), types);
		}

		public static void RegisterDerivedTypesOf(Type type, Assembly assembly)
		{
			RegisterDerivedTypesOf(type, assembly.GetTypes());
		}

		public static void RegisterDerivedTypesOf(Type type, IEnumerable<Type> types)
		{
			List<Type> derivedTypes = GetDerivedTypesOf(type, types);
			_knownTypes = Union(_knownTypes, derivedTypes);
			_knownTypes.Union(types);
		}

		public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
		{
			return _knownTypes;
		}

		private static List<Type> GetDerivedTypesOf(Type baseType, IEnumerable<Type> types)
		{
			return types.Where(t => !t.IsAbstract && t.IsSubclassOf(baseType)).ToList();
		}

		private static List<T> Union<T>(IEnumerable<T> first, IEnumerable<T> second)
		{
			return first.Union(second).ToList();
		}
	}

}
