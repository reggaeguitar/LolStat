using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using DAL.Model;
using System;
using System.Collections.Generic;

namespace LolStat.Models
{
    class SeedDataReader : ISeedDataReader
    {
        private const string _pathToSeedDataFile = @"SeedData.xml";
        private XDocument _doc;
        private XDocument Doc
        {
            get { return _doc ?? (_doc = XDocument.Load(_pathToSeedDataFile)); }
        }

        public ICollection<Champion> GetChampions()
        {
            var champNames = Doc.XPathSelectElements("root/champions/champion");
            return champNames.Select(c => new Champion {Name = c.Value}).ToArray();
        }

        public ICollection<GameType> GetGameTypes()
        {
            var gameTypeNames = Doc.XPathSelectElements("root/gameTypes/gameType");
            return gameTypeNames.Select(g => new GameType {Name = g.Value}).ToArray();
        }

        public ICollection<Map> GetMaps()
        {
            var mapNames = Doc.XPathSelectElements("root/maps/map");
            return mapNames.Select(m => new Map {Name = m.Value}).ToArray();
        }
    }
}
