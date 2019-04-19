using BlankApp1.Services;
using DryIoc;
using Prism.DryIoc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlankApp1.DataStores
{
    public abstract class DataStore<T> : IDataStore<T> where T : class
    {
        #region Properties
        /// <summary>
        /// Database context for ClienteData
        /// </summary>
        private readonly IGenerateDbContext _dbContext;
        private readonly IContainer _appContainer;
        private readonly string _instance = Guid.NewGuid().ToString();
        #endregion

        #region Contructor
        public DataStore(IGenerateDbContext dbContext)
        {
            _dbContext = dbContext;
            _appContainer = (App.Current as PrismApplication).Container.GetContainer();
            Debug.WriteLine($"DataStore check _dbContext:{_dbContext.Instace} instance {_instance}");
        }
        #endregion

        #region Class Implementation
        public virtual Task<IEnumerable<T>> GetItemsAsync()
        {
            Debug.WriteLine($"DataStore GetItemsAsync() instance {_instance}");
            return Task.Run(() =>
            {
                IEnumerable<T> items = null;
                using (var scope = _appContainer.OpenScope())
                {
                    IApplicationDbContext myDbContext = scope.Resolve<IGenerateDbContext>().GenerateNewContext();
                    try
                    {
                        items = myDbContext.Set<T>().ToList<T>();

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetItemsAsync Error ex:{ex.Message}");

                    }
                }

                return items;
            });
        }

        public virtual Task<IEnumerable<T>> GetItemsByPredicateAsync(Func<T, bool> predicate)
        {
            Debug.WriteLine($"DataStore GetItemsByPredicateAsync(Func<T, bool> predicate) instance {_instance}");
            return Task.Run(() =>
            {
                IEnumerable<T> items = null;
                using (var scope = _appContainer.OpenScope())
                {
                    IApplicationDbContext myDbContext = scope.Resolve<IGenerateDbContext>().GenerateNewContext();
                    try
                    {
                        items = myDbContext.Set<T>().Where(predicate);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetItemsByPredicateAsync predicate:{predicate}  Error ex:{ex.Source} {ex.Message} {ex.InnerException} {_instance}");
                        return null;
                    }
                }

                return items;
            });
        }



        #endregion
    }
}