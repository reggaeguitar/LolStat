using DAL;

namespace LolStat.Models
{
    class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IContextFactory _contextFactory;
        private readonly ISeedDataReader _seedDataReader;

        public DatabaseSeeder(IContextFactory contextFactory, ISeedDataReader seedDataReader)
        {
            _contextFactory = contextFactory;
            _seedDataReader = seedDataReader;
        }

        public void Seed()
        {
            var champions = _seedDataReader.GetChampions();
            var gameTypes = _seedDataReader.GetGameTypes();
            var maps = _seedDataReader.GetMaps();
            using (var ctx = _contextFactory.Create())
            {
                ctx.Champions.Clear();
                ctx.Champions.AddRange(champions);

                ctx.GameTypes.Clear();
                ctx.GameTypes.AddRange(gameTypes);

                ctx.Maps.Clear();
                ctx.Maps.AddRange(maps);

                ctx.SaveChanges();
            }
        }
    }
}
