namespace DAL.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LolStatModel : DbContext, ILolStatModel
    {
        public LolStatModel(string appConfigName)
            : base("name=" + appConfigName)
        {
        }

        public virtual IDbSet<Champion> Champions { get; set; }
        public virtual IDbSet<Game> Games { get; set; }
        public virtual IDbSet<GameType> GameTypes { get; set; }
        public virtual IDbSet<Map> Maps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champion>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Champion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameType>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.GameType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Map>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Map)
                .WillCascadeOnDelete(false);
        }
    }

    
}
