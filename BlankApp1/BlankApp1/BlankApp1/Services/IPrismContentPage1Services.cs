using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IPrismContentPage1Services
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
    }
}
