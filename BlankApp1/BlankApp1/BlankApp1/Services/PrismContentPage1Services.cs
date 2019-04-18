using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public class PrismContentPage1Services : IPrismContentPage1Services
    {
        #region Declarations    
        private readonly IChatDataStore _chatDataStore;

        private readonly IMessageDataStore _messageDataStore;
        private readonly string _instance = Guid.NewGuid().ToString();

        #endregion

        #region DelegateCommands

        #endregion

        #region Properties

        #endregion

        #region Constructor
        public PrismContentPage1Services(
            IMessageDataStore messageDataStore,
            IChatDataStore chatDataStore)
        {
            _messageDataStore = messageDataStore;
            _chatDataStore = chatDataStore;
            $"PrismContentPage1Services check instance {_instance}".ConsoleText();

        }


        #endregion

        #region Private Methods

        #endregion

        #region Interface Implementation
        public Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return _messageDataStore.GetItemsAsync();
        }
        #endregion

        #region Overrides Methods

        #endregion
    }
}
