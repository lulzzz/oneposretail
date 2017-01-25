namespace OnePos.ServiceInterface.Mapper
{
    public interface IFactoryDomainMapper<in TMessage, out TDomain>
    {
        TDomain ToDomain(TMessage message);
    }
}
