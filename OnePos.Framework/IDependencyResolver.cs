using System;

namespace OnePos.Framework
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
        T Resolve<T>(string neme);
        object Resolve(Type @interface);
        object Resolve(string name, Type @interface);
    }
}
