namespace OnePos.ServiceInterface.Mapper
{
    public interface IMapper<TDomain, TMessage> : IFactoryMessageMapper<TDomain, TMessage>, IFactoryDomainMapper<TMessage, TDomain>
    {
    }
}
