namespace TOS.Data.EntityFramework.Mapping
{
    public interface IIdHelper<TModel, TId>
    {
        TId GetModelId(TModel model);
        object[] ToEntityKey(TId id);
    }
}
