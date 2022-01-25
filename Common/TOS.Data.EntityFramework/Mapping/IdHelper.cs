using TOS.Common.DataModel;
using TOS.Common.Utils;

namespace TOS.Data.EntityFramework.Mapping
{
    public class IdHelper<TModel, TId> : IIdHelper<TModel, TId>
    {
        private readonly IExceptionHelper _exceptionHelper;

        public IdHelper(IExceptionHelper exceptionHelper)
        {
            _exceptionHelper = exceptionHelper;
        }

        public TId GetModelId(TModel model)
        {
            _exceptionHelper.CheckInvalidOperationException(!typeof(IBasedModel<TId>).IsAssignableFrom(typeof(TModel)),
                $"{typeof(TModel).FullName} does not implement ${typeof(IBasedModel<TId>).FullName}.");
            return ((IBasedModel<TId>)model).Id;
        }

        public object[] ToEntityKey(TId id)
        {
            if (typeof(object[]).IsAssignableFrom(typeof(TId)))
            {
                return id as object[];
            }
            return new object[] { id };
        }
    }
}
