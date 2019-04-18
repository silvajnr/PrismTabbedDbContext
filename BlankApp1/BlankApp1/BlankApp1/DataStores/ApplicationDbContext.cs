using BlankApp1.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BlankApp1.DataStores
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Private declaration
        readonly ISQLite _dbPath;
        private readonly string _instance = Guid.NewGuid().ToString();
        public string Instace { get => _instance; }
        #endregion

        #region Constructor
        public ApplicationDbContext(ISQLite dbPath)
        {

            _dbPath = dbPath;
            $"ApplicationDbContext check instance {_instance}".ConsoleText();


            try
            {
                //Database.EnsureDeleted();
                //Database.EnsureCreated();
                Database.Migrate();

                // Verify that all previous data is kept
                Debug.WriteLine($"Current database content instance {_instance}");

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error Ctor DbContext ex:{ex.Source} {ex.Message} {ex.InnerException} instance {_instance}");
            }

            //

        }
        #endregion

        #region DbSets        
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatDetail> ChatDetails { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatDetail> Contacts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Message> ContactDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        #region Configuration Overrides 
        protected override void OnModelCreating(ModelBuilder builder)
        {


            #region Defining Primary Keys    
            //One To One Chat ChatDetail
            builder.Entity<Chat>()
                .HasOne<ChatDetail>(s => s.ChatDetails)
                .WithOne(ad => ad.Chats)
                .HasForeignKey<ChatDetail>(ad => ad.ChatId);

            //One To Many Chat Message
            builder.Entity<Message>()
                .HasOne<Chat>(s => s.Chats)
                .WithMany(g => g.Messages)
                .HasForeignKey(s => s.ChatId);

            #endregion


            #region  Defining Properties
            //modelBuilder.Entity<LoginCredentialsDataModel>().Property(a => a.Name).HasMaxLength(25);
            #endregion

            base.OnModelCreating(builder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine($"OnConfiguring {_dbPath.GetDbUrl()} instance {_instance}");
            optionsBuilder.UseSqlite($"Filename={_dbPath.GetDbUrl()}");
            base.OnConfiguring(optionsBuilder);
        }

        int IApplicationDbContext.SaveChanges()
        {
            return base.SaveChanges();
        }

        Task<int> IApplicationDbContext.SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override void Dispose()
        {
            $"ApplicationDbContext Dispose() instance {_instance}".ConsoleText();
            base.Dispose();
        }
        #endregion

    }

}
