using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace LolStatCore
{
    public class GameComparer : IEqualityComparer<Game>
    {
        public bool Equals(Game x, Game y)
        {
            return x.Assists == y.Assists &&
                   x.ChampionID == y.ChampionID &&
                   x.CreepScore == y.CreepScore &&
                   x.Date == y.Date &&
                   x.Deaths == y.Deaths &&
                   x.GameTypeID == y.GameTypeID &&
                   x.Gold == y.Gold &&
                   x.IsWin == y.IsWin &&
                   x.Kills == y.Kills &&
                   x.Level == y.Level &&
                   x.MapID == y.MapID &&
                   x.Time == y.Time;
        }

        public int GetHashCode(Game game)
        {
            return game.Assists ^
                   game.ChampionID ^
                   game.CreepScore ^
                   game.Date.GetHashCode() ^
                   game.Deaths ^
                   game.GameTypeID ^
                   game.Gold.GetHashCode() ^
                   game.IsWin.GetHashCode() ^
                   game.Kills ^
                   game.Level ^
                   game.MapID ^
                   game.Time.GetHashCode();
        }
    }
}
