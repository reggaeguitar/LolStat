namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Game
    {
        public int ID { get; set; }

        public int ChampionID { get; set; }

        public int MapID { get; set; }

        public int GameTypeID { get; set; }

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public int Assists { get; set; }

        public double Gold { get; set; }

        public int CreepScore { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public bool? IsWin { get; set; }

        public int Level { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual GameType GameType { get; set; }

        public virtual Map Map { get; set; }
    }
}
