using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using TOS.Common.Utils;

namespace TOS.Data.EntityFramework
{
    public static class EFCoreExtensions
    {
        public static TEntity FindTracked<TEntity>(this DbContext context, params object[] keyValues)
            where TEntity : class
        {
            IKey key = context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey();
            return context.ChangeTracker.Entries<TEntity>().FirstOrDefault(e => CheckKeysAreTheSame(key, e, keyValues))?.Entity;
        }

        public static TEntity AssignKeys<TEntity>(this DbContext context, TEntity entity, params object[] keyValues)
        {
            IKey key = context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey();
            int count = 0;
            foreach (IProperty property in key.Properties)
            {
                property.PropertyInfo.SetValue(entity, keyValues[count++]);
            }
            return entity;
        }

        private static bool CheckKeysAreTheSame(IKey key, EntityEntry entry, object[] keyValues)
        {
            int count = 0;
            foreach (IProperty property in key.Properties)
            {
                if (!EqualityHelper.AreEquals(entry.CurrentValues.GetValue<object>(property), keyValues[count++]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
