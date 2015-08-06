using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using DAL.Model;
using LolStatCore;

namespace DataImporter
{
    class Program
    {
        private const int StartLine = 6;

        static void Main()
        {
            var lines = File.ReadAllLines("data.txt").Where(x => x.Trim() != "").ToArray();
            File.WriteAllLines("data.txt", lines);
            int i = StartLine;
            var gameComparer = new GameComparer();
            using (var ctx = new LolStatModel())
            {
                var gamesInDb = ctx.Games.ToList();
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
                    bool add = true;
                    foreach (var game in gamesInDb)
                    {
                        if (gameComparer.Equals(game, newGame))
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                    {
                        ctx.Games.Add(newGame);
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}
