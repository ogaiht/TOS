using System;
using System.Collections.Generic;
using TOS.Common.MongoDB;
using TOS.Common.Text.Semantics;

namespace TOS.Data.MongoDB
{
    public class CollectionNameProvider : ICollectionNameProvider
    {
        private readonly IPlurilizer _plurilizer;
        private readonly Dictionary<Type, string> _collectionNames;

        public CollectionNameProvider(IPlurilizer plurilizer)
        {
            _plurilizer = plurilizer;
            _collectionNames = new Dictionary<Type, string>();
        }

        public string GetCollectionName<TModel>()
        {
            Type modelType = typeof(TModel);
            if (!_collectionNames.TryGetValue(modelType, out string name))
            {
                object[] collectionName = modelType.GetCustomAttributes(typeof(CollectionNameAttribute), false);
                if (collectionName != null && collectionName.Length == 1)
                {
                    name = ((CollectionNameAttribute)collectionName[0]).Name;
                }
                else
                {
                    name = _plurilizer.Plurilize(modelType.Name);
                }
                _collectionNames.Add(modelType, name);
            }
            return name;
        }
    }
}
