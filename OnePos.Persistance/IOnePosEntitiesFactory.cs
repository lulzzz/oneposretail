using OnePos.Framework;

namespace OnePos.Persistance
{
    public interface IOnePosEntitiesFactory
    {
        IOnePosEntities Create(string dataSource = null, string connectionString=null);
    }

    public class OnePosEntitiesFactory : IOnePosEntitiesFactory
    {
        private readonly IDependencyContainer _container;

        public OnePosEntitiesFactory(IDependencyContainer container)
        {
            _container = container;
        }

        #region IOnePosEntitiesFactory Members

        public IOnePosEntities Create(string dataSource=null, string connectionString = null)
        {
            IOnePosEntities onePosEntities;
            if (!string.IsNullOrEmpty(dataSource) && !string.IsNullOrEmpty(connectionString))
            {
                onePosEntities = _container.Resolve<IOnePosEntities>().CreateEntitiesForSpecificDatabaseName(dataSource, connectionString);
            }
            else {
                onePosEntities = _container.Resolve<IOnePosEntities>();
            }
            // Need to release the object otherwise there will be memoery leaks

            onePosEntities.OnDisposed += (sender, args) => _container.Release(sender);
            onePosEntities.CommandTimeout = 0;

            return onePosEntities;
        }
        #endregion
    }
}
