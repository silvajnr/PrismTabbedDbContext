using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IPrismContentPage3Services
    {
        Task<IEnumerable<Chat>> GetChatsWithDetailsAsync();

        Task<IEnumerable<Chat>> GetChatsByDateAsync(Func<Chat, bool> predicate);
    }

}
