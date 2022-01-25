using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.Utils;
using TOS.Data.EntityFramework.Mapping;
using TOS.Data.Repositories;

namespace TOS.Data.EntityFramework.Repositories
{
    public abstract class Repository<TModel, TId, TEntity, TDbContext>
        : IRepository<TModel, TId>
        where TDbContext : DbContext
        where TModel : class
        where TEntity : class, new()
    {
        protected IMappingServices<TModel, TId> MappingServices { get; }
        protected TDbContext DbContext { get; }
        protected IExceptionHelper ExceptionHelper { get; }
        protected ILogger Logger { get; }

        protected Repository(
            TDbContext dbContext,            
            IMappingServices<TModel, TId> mappingServices,
            ILogger logger,
            IExceptionHelper exceptionHelper)
        {
            DbContext = dbContext;
            MappingServices = mappingServices;
            Logger = logger;
            ExceptionHelper = exceptionHelper;
        }

        public virtual TId Add(TModel model)
        {
            ExceptionHelper.CheckArgumentNullException(model, nameof(model));
            TEntity entity = ToEntity(model);
            ExecuteAndSave(() => DbContext.Set<TEntity>().Add(entity));
            ToModel(entity, model);
            return MappingServices.IdHelper.GetModelId(model);
        }

        public virtual async Task<TId> AddAsync(TModel model)
        {
            ExceptionHelper.CheckArgumentNullException(model, nameof(model));
            TEntity entity = ToEntity(model);
            await ExecuteAndSaveAsync(async () => await DbContext.Set<TEntity>().AddAsync(entity));
            ToModel(entity, model);
            return MappingServices.IdHelper.GetModelId(model);
        }

        public virtual void AddRange(IEnumerable<TModel> models)
        {
            ExceptionHelper.CheckArgumentNullException(models, nameof(models));
            if (!models.Any())
            {
                return;
            }
            Dictionary<TEntity, TModel> entityModelMap = CreateDictionaryForInsert(models);
            IEnumerable<TEntity> entities = entityModelMap.Keys;
            ExecuteAndSave(() => DbContext.Set<TEntity>().AddRange(entities));
            UpdateModels(entityModelMap);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TModel> models)
        {
            ExceptionHelper.CheckArgumentNullException(models, nameof(models));
            if (!models.Any())
            {
                return;
            }
            Dictionary<TEntity, TModel> entityModelMap = CreateDictionaryForInsert(models);
            IEnumerable<TEntity> entities = entityModelMap.Keys;
            await ExecuteAndSaveAsync(async () => await DbContext.Set<TEntity>().AddRangeAsync(entities));
            UpdateModels(entityModelMap);
        }

        public virtual bool Delete(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            TEntity entity = GetEntityForDeletion(id);
            return ExecuteAndSave(() => DbContext.Set<TEntity>().Remove(entity)) > 0;
        }

        public virtual async Task<bool> DeleteAsync(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            TEntity entity = GetEntityForDeletion(id);
            return await ExecuteAndSaveAsync(() =>
            {
                DbContext.Set<TEntity>().Remove(entity);
                return Task.CompletedTask;
            }) > 0;
        }

        public virtual TModel GetById(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            object[] key = MappingServices.IdHelper.ToEntityKey(id);
            TEntity entity = DbContext.Set<TEntity>().Find(key);
            if (entity == null)
            {
                return null;
            }
            return ToModel(entity);
        }

        public virtual async Task<TModel> GetByIdAsync(TId id)
        {
            ExceptionHelper.CheckArgumentNullException(id, nameof(id));
            object[] key = MappingServices.IdHelper.ToEntityKey(id);
            TEntity entity = await DbContext.Set<TEntity>().FindAsync(key);
            if (entity == null)
            {
                return null;
            }
            return ToModel(entity);
        }

        public virtual void Update(TModel model)
        {
            ExceptionHelper.CheckArgumentNullException(model, nameof(model));
            TId id = MappingServices.IdHelper.GetModelId(model);
            object[] key = MappingServices.IdHelper.ToEntityKey(id);
            TEntity entity = DbContext.Set<TEntity>().Find(key);
            if (entity == null)
            {

            }
            ToEntity(model, entity);
            DbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            ExceptionHelper.CheckArgumentNullException(model, nameof(model));
            TId id = MappingServices.IdHelper.GetModelId(model);
            object[] key = MappingServices.IdHelper.ToEntityKey(id);
            TEntity entity = await DbContext.Set<TEntity>().FindAsync(key);
            if (entity == null)
            {

            }
            ToEntity(model, entity);
            await DbContext.SaveChangesAsync();
        }

        protected virtual TEntity ToEntity(TModel model, TEntity entity = default)
        {
            if (entity == null)
            {
                return MappingServices.Mapper.Map<TEntity>(model);
            }
            return MappingServices.Mapper.Map(model, entity);
        }

        protected virtual TModel ToModel(TEntity entity, TModel model = default)
        {
            if (model == null)
            {
                return MappingServices.Mapper.Map<TModel>(entity);
            }
            return MappingServices.Mapper.Map(entity, model);
        }

        protected int ExecuteAndSave(Action execution)
        {
            execution();
            return DbContext.SaveChanges();
        }

        protected async Task<int> ExecuteAndSaveAsync(Func<Task> execution)
        {
            await execution();
            return await DbContext.SaveChangesAsync();
        }

        private Dictionary<TEntity, TModel> CreateDictionaryForInsert(IEnumerable<TModel> models)
        {
            return models.ToDictionary(m => ToEntity(m), m => m);
        }

        private void UpdateModels(Dictionary<TEntity, TModel> entityModelMap)
        {
            foreach (KeyValuePair<TEntity, TModel> entityModel in entityModelMap)
            {
                ToModel(entityModel.Key, entityModel.Value);
            }
        }

        private TEntity GetEntityForDeletion(TId id)
        {
            object[] keys = MappingServices.IdHelper.ToEntityKey(id);
            TEntity entity = DbContext.FindTracked<TEntity>(keys) ?? DbContext.AssignKeys(new TEntity(), keys);
            return entity;
        }
    }
}
