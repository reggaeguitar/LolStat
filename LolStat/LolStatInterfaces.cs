using System.Collections.Generic;
using DAL.Model;
using LolStat.Models;

namespace LolStat
{
    // this interface is solely for Castle Windsor dependency injection
    public interface IMainViewModel
    {
         
    }

    public interface IMainWindow
    {
        void Show();
    }

    public interface IDatabaseChecker
    {
        bool HasNonGameData();
    }

    public interface IDatabaseSeeder
    {
        void Seed();
    }

    public interface ISeedDataReader
    {
        ICollection<Champion> GetChampions();
        ICollection<GameType> GetGameTypes();
        ICollection<Map> GetMaps();
    }

    public interface IDataLoader
    {
        ICollection<Game> LoadGames();
        ICollection<ChampInfo> LoadChampInfos();
    }
}
