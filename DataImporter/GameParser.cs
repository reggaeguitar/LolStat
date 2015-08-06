using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Model;

namespace DataImporter
{
    public class GameParser : IGameParser
    {
        private const int StartLine = 6;

        private readonly IContextFactory _contextFactory;

        public GameParser(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IEnumerable<Game> Parse(string data)
        {
            var games = new List<Game>();
            var lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            lines = lines.Where(x => x.Trim() != "").ToArray();
            int i = StartLine;
            using (var ctx = _contextFactory.Create())
            {
                while (i < lines.Length - 1)
                {
                    var level = Int32.Parse(lines[++i]);
                    var champ = lines[++i];
                    var map = lines[++i];
                    var gameType = lines[++i];
                    var kda = lines[++i].Split('/').Select(Int32.Parse).ToArray();
                    var kills = kda[0];
                    var deaths = kda[1];
                    var assists = kda[2];
                    var creepScore = Int32.Parse(lines[++i]);
                    var gold = Double.Parse(lines[++i].Replace("k", "")) * 1000d;
                    var timeLine = lines[++i].Split(':').Select(Int32.Parse).ToArray();
                    bool overAnHour = timeLine.Length > 2;
                    TimeSpan time = overAnHour
                        ? new TimeSpan(timeLine[0], timeLine[1], timeLine[2])
                        : new TimeSpan(0, timeLine[0], timeLine[1]);
                    var date = DateTime.Parse(lines[++i]);
                    var newGame = new Game
                    {
                        Level = level,
                        Assists = assists,
                        ChampionID = ctx.Champions.Single(x => x.Name == champ).ID,
                        MapID = ctx.Maps.Single(x => x.Name == map).ID,
                        GameTypeID = ctx.GameTypes.Single(x => x.Name == gameType).ID,
                        Kills = kills,
                        Deaths = deaths,
                        Date = date,
                        CreepScore = creepScore,
                        Gold = gold,
                        Time = time
                    };
                    games.Add(newGame);
                }
            }
            return games;
        }
    }
}
