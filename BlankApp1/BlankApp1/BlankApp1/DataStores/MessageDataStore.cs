using BlankApp1.Services;
using System;

namespace BlankApp1.DataStores
{
    public class MessageDataStore : DataStore<Message>, IMessageDataStore
    {
        #region Properties
        private readonly IGenerateDbContext _dbContext;
        private readonly string _instance = Guid.NewGuid().ToString();
        #endregion

        #region Contructor
        public MessageDataStore(IGenerateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;

            $"MessageDataStore _dbContext:{_dbContext.Instace} check instance {_instance}".ConsoleText();
        }
        #endregion

        #region Interface Implementation
        #endregion

        #region Generic Interface Overrides
        #endregion

        #region Private Methods
        #endregion
    }
}
