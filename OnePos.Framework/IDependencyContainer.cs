using System;
using System.Collections.Generic;

namespace OnePos.Framework
{
    public interface IDependencyContainer : IDependencyResolver
    {
        void RegisterSingleton<I, T>()
            where I : class where T : I;

        void RegisterSingleton(Type @interface, Type implementation);

        void RegisterInstance<T>(T instance)
            where T : class;

        void RegisterInstance<I, T>(T instance)
            where I : class where T : I;

        void Register<I, T>()
            where I : class where T : I;

        void Register(Type @interface, Type implementation);

        void RegisterPerRequest<I, T>()
            where I : class where T : I;

        void RegisterPerRequest(Type @interface, Type implementation);

        void RegisterPerThread<I, T>()
            where I : class where T : I;

        void RegisterPerThread(Type @interface, Type implementation);

        void RegisterFactoryFor<I>(Func<I> factoryMethod)
            where I : class;

        bool IsRegistered<T>();
        bool IsRegistered(Type @interface);
        void Release(object objectToRelease);
        void Register(IEnumerable<Type> types);
    }
}