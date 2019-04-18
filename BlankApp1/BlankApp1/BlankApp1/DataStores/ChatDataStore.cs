using BlankApp1.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlankApp1.DataStores
{
    public class ChatDataStore : DataStore<Chat>, IChatDataStore
    {
        #region Properties
        /// <summary>
        /// Database context for ChatDataStore
        /// </summary>
        private readonly IGenerateDbContext _dbContext;

        private readonly string _instance = Guid.NewGuid().ToString();
        #endregion

        #region Contructor
        public ChatDataStore(IGenerateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            Debug.WriteLine($"ChatDataStore _dbContext:{_dbContext.Instace} check instance {_instance}");
        }


        #endregion

        #region Class Overrides

        #endregion

        #region Class Implemetation
        public Task<IEnumerable<Chat>> GetChatsAsync()
        {
            $"ChatDataStore GetChatsAsync() instance {_instance}".ConsoleText();
            return Task.Run(() =>
            {
                IEnumerable<Chat> items = default(IEnumerable<Chat>);
                using (IApplicationDbContext myDbContext = _dbContext.GenerateNewContext())
                {
                    try
                    {
                        items = myDbContext.Chats
                        .Include(c => c.ChatDetails)
                        .OrderBy(o => o.DateCreated);

                    }
                    catch (Exception ex)
                    {
                        $"GetItemsAsync Error ex:{ex.Source} {ex.Message} {ex.InnerException} {_instance}".ConsoleText();

                    }
                }
                return items;
            });
        }
        #endregion
    }
}
