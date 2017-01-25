using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace OnePos.Framework
{
    public class WindsorDependencyContainer : IDependencyContainer
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyContainer(IWindsorContainer container)
        {
            _container = container;
        }

        #region IDependencyResolver

        public I Resolve<I>()
        {
            return _container.Resolve<I>();
        }

        public I Resolve<I>(string name)
        {
            return _container.Resolve<I>(name);
        }

        public object Resolve(Type @interface)
        {
            return _container.Resolve(@interface);
        }

        public object Resolve(string name, Type @interface)
        {
            return _container.Resolve(@interface, name);
        }

        #endregion

        #region IDependencyContainer

        public void RegisterInstance<T>(T instance)
            where T : class
        {
            _container.Register(Component.For<T>().Instance(instance));
        }

        public void RegisterInstance<I, T>(T instance)
            where I : class
            where T : I
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.Transient
                                    .Instance(instance));
        }

        public void RegisterSingleton<I, T>()
            where I : class
            where T : I
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.Singleton
                                    .ImplementedBy<T>());
        }

        public void RegisterSingleton(Type @interface, Type implementation)
        {
            _container.Register(Component.For(@interface)
                                    .LifeStyle.Singleton
                                    .ImplementedBy(implementation));
        }

        public void Register<I, T>()
            where I : class
            where T : I
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.Transient
                                    .ImplementedBy<T>());
        }

        public void Register(Type @interface, Type implementation)
        {
            _container.Register(Component.For(@interface)
                                    .LifeStyle.Transient
                                    .ImplementedBy(implementation));
        }

        public void RegisterPerRequest<I, T>()
            where I : class
            where T : I
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.PerWebRequest
                                    .ImplementedBy<T>());
        }

        public void RegisterPerRequest(Type @interface, Type implementation)
        {
            _container.Register(Component.For(@interface)
                                    .LifeStyle.PerWebRequest
                                    .ImplementedBy(implementation));
        }

        public void RegisterPerThread<I, T>()
            where I : class
            where T : I
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.PerThread
                                    .ImplementedBy<T>());
        }

        public void RegisterPerThread(Type @interface, Type implementation)
        {
            _container.Register(Component.For(@interface)
                                    .LifeStyle.PerThread
                                    .ImplementedBy(implementation));
        }

        public void RegisterFactoryFor<I>(Func<I> factoryMethod)
            where I : class
        {
            _container.Register(Component.For<I>()
                                    .LifeStyle.Transient
                                    .UsingFactoryMethod(factoryMethod));
        }

        public bool IsRegistered<T>()
        {
            return IsRegistered(typeof (T));
        }

        public bool IsRegistered(Type @interface)
        {
            return _container.Kernel.GetAssignableHandlers(@interface).Any();
        }

        public void Release(object objectToRelease)
        {
            // No need to do this, the _container.Release will do it
            //if ( (objectToRelease as IDisposable) != null) (objectToRelease as IDisposable).Dispose();

            _container.Release(objectToRelease);
        }

        #endregion

        #region IDependencyContainer Members

        public void Register(IEnumerable<Type> types)
        {
            foreach (Type type in types)
            {
                if (!type.IsClass || type.IsAbstract)
                    continue;
                RegisterImplementationWithAllInterfaces(type);
            }
        }

        #endregion

        private void RegisterImplementationWithAllInterfaces(Type implementation)
        {
            IList<Type> possibleServices = implementation.GetInterfaces().ToList();
            foreach (Type possibleService in possibleServices)
            {
                Type service = possibleService;
                if (service.IsGenericTypeDefinition)
                    service = service.GetGenericTypeDefinition();

                if (IsRegistered(service)) continue;

                Register(service, implementation);
            }
        }
    }
}
