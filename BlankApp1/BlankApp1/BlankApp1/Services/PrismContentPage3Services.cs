using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public class PrismContentPage3Services : IPrismContentPage3Services
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="navigationService"></param>
        /// 
        public PrismContentPage3Services(
            IMessageDataStore messageDataStore,
            IChatDataStore chatDataStore)
        {
            _messageDataStore = messageDataStore;
            _chatDataStore = chatDataStore;
            $"PrismContentPage3Services check instance {_instance}".ConsoleText();

        }


        #endregion

        #region Private Methods

        #endregion

        #region Interface Implementation
        public Task<IEnumerable<Chat>> GetChatsWithDetailsAsync()
        {
            return _chatDataStore.GetChatsAsync();
        }

        public Task<IEnumerable<Chat>> GetChatsByDateAsync(Func<Chat, bool> predicate)
        {
            return _chatDataStore.GetItemsByPredicateAsync(predicate);
        }


        #endregion

        #region Overrides Methods

        #endregion
    }
}
