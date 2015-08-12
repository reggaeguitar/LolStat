using System;
using System.Data.Entity;
using DAL.Model;

namespace DAL
{
    public interface ILolStatModel : IDisposable
    {
        DbSet<Champion> Champions { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<GameType> GameTypes { get; set; }
        DbSet<Map> Maps { get; set; }
        int SaveChanges();
    }

    public interface IContextFactory
    {
        ILolStatModel Create();
    }
}
