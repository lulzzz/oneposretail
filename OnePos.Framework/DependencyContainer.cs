using Castle.Windsor;

namespace OnePos.Framework
{
    public static class DependencyContainer
    {
        static DependencyContainer()
        {
            Default = new WindsorDependencyContainer(new WindsorContainer());
        }

        public static IDependencyContainer Default { get; set; }
    }
}
