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
            throw new NotImplementedException();
            using (var ctx = _contextFactory.Create())
            {
                // todo implement this
            }
        }
    }
}
