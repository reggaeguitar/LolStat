using System.Linq;
using DAL;

namespace LolStat.Models
{
    public class DatabaseChecker : IDatabaseChecker
    {
        private readonly IContextFactory _contextFactory;

        public DatabaseChecker(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public bool HasNonGameData()
        {
            return HasChampions() && HasGameTypes() && HasMaps();
        }

        private bool HasMaps()
        {
            using (var ctx = _contextFactory.Create())
            {
                return ctx.Maps.Count() == (int)Properties.Settings.Default["MapCount"];
            }
        }

        private bool HasGameTypes()
        {
            using (var ctx = _contextFactory.Create())
            {
                return ctx.GameTypes.Count() == (int)Properties.Settings.Default["GameTypeCount"];
            }
        }

        private bool HasChampions()
        {
            using (var ctx = _contextFactory.Create())
            {
                return ctx.Champions.Count() == (int)Properties.Settings.Default["ChampionCount"];
            }
        }
    }
}
