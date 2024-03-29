﻿using BlankApp1.Services;
using DryIoc;
using Microsoft.EntityFrameworkCore;
using Prism.DryIoc;
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
        private readonly IContainer _appContainer;
        private readonly string _instance = Guid.NewGuid().ToString();
        #endregion

        #region Contructor
        public ChatDataStore(IGenerateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _appContainer = (App.Current as PrismApplication).Container.GetContainer();
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
                using (var scope = _appContainer.OpenScope())
                {
                    IApplicationDbContext myDbContext = scope.Resolve<IGenerateDbContext>().GenerateNewContext();
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
