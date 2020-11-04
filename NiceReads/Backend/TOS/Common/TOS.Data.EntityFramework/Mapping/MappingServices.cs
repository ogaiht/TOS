using AutoMapper;

namespace TOS.Data.EntityFramework.Mapping
{
    public class MappingServices<TModel, TId> : IMappingServices<TModel, TId>
    {
        public MappingServices(IMapper mapper, IIdHelper<TModel, TId> idHelper)
        {
            Mapper = mapper;
            IdHelper = idHelper;
        }

        public IMapper Mapper { get; }

        public IIdHelper<TModel, TId> IdHelper { get; }
    }
}
