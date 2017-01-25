namespace OnePos.ServiceInterface.Mapper
{
    public interface IFactoryMessageMapper<in TDomain, out TMessage>
    {
        TMessage ToMessage(TDomain domain);
    }
}
