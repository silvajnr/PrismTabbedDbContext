using System;

namespace BlankApp1.Services
{
    public interface IGenerateDbContext : IDisposable
    {
        string Instace
        {
            get;
        }
        IApplicationDbContext GenerateNewContext();

    }
}
