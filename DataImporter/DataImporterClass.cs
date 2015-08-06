using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using DAL;
using DAL.Model;

namespace DataImporter
{
    public class DataImporterClass : IDataImporterClass
    {
        private readonly IContextFactory _contextFactory;
        private readonly IGameParser _gameParser;

        public DataImporterClass(IContextFactory contextFactory, IGameParser gameParser)
        {
            _contextFactory = contextFactory;
            _gameParser = gameParser;
        }

        public void Import(string data)
        {
            var games = _gameParser.Parse(data);
            using (var ctx = _contextFactory.Create())
            {
                var gamesInDb = ctx.Games.ToList();
                bool add = true;
                var gameComparer = new GameComparer();
                foreach (var game in games)
                {
                    foreach (var gameInDb in gamesInDb)
                    {
                        if (gameComparer.Equals(game, gameInDb))
                        {
                            add = false;
                            break;
                        }
                    }
                    if (add)
                    {
                        ctx.Games.Add(game);
                    }
                }
                ctx.SaveChanges();
            }
        }
    }
}
