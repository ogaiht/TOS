namespace TOS.Data.EntityFramework.Repositories
{
    public interface IEntityModelIdParser<TModel, TId>
    {
        object[] GetEntityKey(TId id);
        TId GetModelId(TModel model);
    }
}