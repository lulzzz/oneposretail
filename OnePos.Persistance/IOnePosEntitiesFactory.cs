using OnePos.Framework;

namespace OnePos.Persistance
{
    public interface IOnePosEntitiesFactory
    {
        IOnePosEntities Create();
    }

    public class OnePosEntitiesFactory : IOnePosEntitiesFactory
    {
        private readonly IDependencyContainer _container;

        public OnePosEntitiesFactory(IDependencyContainer container)
        {
            _container = container;
        }

        #region IOnePosEntitiesFactory Members

        public IOnePosEntities Create()
        {
            var onePosEntities = _container.Resolve<IOnePosEntities>();
            // Need to release the object otherwise there will be memoery leaks

            onePosEntities.OnDisposed += (sender, args) => _container.Release(sender);
            onePosEntities.CommandTimeout = 0;

            return onePosEntities;
        }
        #endregion
    }
}
