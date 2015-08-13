using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model;

namespace LolStat.Models
{
    class DataLoader : IDataLoader
    {
        private readonly IContextFactory _contextFactory;

        public DataLoader(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public ICollection<Game> LoadGames()
        {
            using (var ctx = _contextFactory.Create())
            {
                return ctx.Games
                    .Include("Champion")
                    .Include("GameType")
                    .Include("Map")
                    .ToArray();
            }
        }

        public ICollection<ChampInfo> LoadChampInfos()
        {
            var champInfos = new List<ChampInfo>();
            using (var ctx = _contextFactory.Create())
            {
                var games = LoadGames();
                var gamesGroupedByChamp = games.GroupBy(x => x.Champion).ToArray();
                foreach (var champ in gamesGroupedByChamp)
                {
                    var curInfo = new ChampInfo();
                    curInfo.AverageAssists = champ.Average(x => x.Assists);
                    curInfo.AverageCreepScore = champ.Average(x => x.CreepScore);
                    curInfo.AverageDeaths = champ.Average(x => x.Deaths);
                    curInfo.AverageGold = champ.Average(x => x.Gold);
                    curInfo.AverageKills = champ.Average(x => x.Kills);
                    curInfo.AverageLevel = champ.Average(x => x.Level);

                    // from http://stackoverflow.com/questions/8847679/find-average-of-collection-of-timespans
                    double doubleAverageTicks = champ.Average(x => x.Time.Ticks);
                    long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
                    curInfo.AverageTime = new TimeSpan(longAverageTicks);

                    curInfo.MaxAssists = champ.Max(x => x.Assists);
                    curInfo.MaxCreepScore = champ.Max(x => x.CreepScore);
                    curInfo.MaxDeaths = champ.Max(x => x.Deaths);
                    curInfo.MaxGold = champ.Max(x => x.Gold);
                    curInfo.MaxKills = champ.Max(x => x.Kills);
                    curInfo.MaxLevel = champ.Max(x => x.Level);

                    curInfo.MinAssists = champ.Min(x => x.Assists);
                    curInfo.MinCreepScore = champ.Min(x => x.CreepScore);
                    curInfo.MinDeaths = champ.Min(x => x.Deaths);
                    curInfo.MinGold = champ.Min(x => x.Gold);
                    curInfo.MinKills = champ.Min(x => x.Kills);
                    curInfo.MinLevel = champ.Min(x => x.Level);

                    curInfo.Name = champ.Key.Name;

                    curInfo.TotalAssists = champ.Sum(x => x.Assists);
                    curInfo.TotalCreepScore = champ.Sum(x => x.CreepScore);
                    curInfo.TotalDeaths = champ.Sum(x => x.Deaths);
                    curInfo.TotalGames = champ.ToArray().Count();
                    curInfo.TotalGold = champ.Sum(x => x.Gold);
                    curInfo.TotalKills = champ.Sum(x => x.Kills);
                    curInfo.TotalLevel = champ.Sum(x => x.Level);

                    // from http://stackoverflow.com/questions/4703046/sum-of-timespans-in-c-sharp
                    curInfo.TotalTime = new TimeSpan(champ.Sum(r => r.Time.Ticks));

                    champInfos.Add(curInfo);
                }
            }
            return champInfos;
        }
    }
}
