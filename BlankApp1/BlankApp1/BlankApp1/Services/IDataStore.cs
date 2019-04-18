using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IDataStore<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetItemsAsync();
        Task<IEnumerable<TEntity>> GetItemsByPredicateAsync(Func<TEntity, bool> predicate);
    }
}
