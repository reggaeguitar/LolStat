using System;
using System.Data.Entity;
using DAL.Model;

namespace DAL
{
    public interface ILolStatModel : IDisposable
    {
        IDbSet<Champion> Champions { get; set; }
        IDbSet<Game> Games { get; set; }
        IDbSet<GameType> GameTypes { get; set; }
        IDbSet<Map> Maps { get; set; }
        int SaveChanges();
    }

    public interface IContextFactory
    {
        ILolStatModel Create();
    }
}
