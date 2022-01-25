using AutoMapper;

namespace TOS.Data.EntityFramework.Mapping
{
    public interface IMappingServices<TModel, TId>
    {
        IMapper Mapper { get; }
        IIdHelper<TModel, TId> IdHelper { get; }
    }
}
