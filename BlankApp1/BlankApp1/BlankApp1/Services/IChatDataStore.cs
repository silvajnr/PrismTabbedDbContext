using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IChatDataStore : IDataStore<Chat>
    {
        Task<IEnumerable<Chat>> GetChatsAsync();
    }
}
