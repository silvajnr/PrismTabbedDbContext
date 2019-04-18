using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlankApp1.Services
{
    public interface IApplicationDbContext : IDisposable
    {
        string Instace
        {
            get;
        }

        DbSet<Chat> Chats { get; set; }

        DbSet<ChatDetail> ChatDetails { get; set; }

        DbSet<Message> Messages { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

    }


}
