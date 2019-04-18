using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IPrismContentPage2Services
    {
        Task<IEnumerable<Chat>> GetChatsAsync();
    }
}
