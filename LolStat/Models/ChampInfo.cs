﻿using System;

namespace LolStat.Models
{
    public class ChampInfo
    {
        public string Name { get; set; }
        public int TotalGames { get; set; }
        public int TotalKills { get; set; }
        public double AverageKills { get; set; }
        public int MaxKills { get; set; }
        public int MinKills { get; set; }
        public int TotalDeaths { get; set; }
        public double AverageDeaths { get; set; }
        public int MaxDeaths { get; set; }
        public int MinDeaths { get; set; }
        public int TotalAssists { get; set; }
        public double AverageAssists { get; set; }
        public int MaxAssists { get; set; }
        public int MinAssists { get; set; }
        public double TotalGold { get; set; }
        public double AverageGold { get; set; }
        public double MaxGold { get; set; }
        public double MinGold { get; set; }
        public int TotalCreepScore { get; set; }
        public double AverageCreepScore { get; set; }
        public int MaxCreepScore { get; set; }
        public int MinCreepScore { get; set; }
        public int TotalLevel { get; set; }
        public double AverageLevel { get; set; }
        public int MaxLevel { get; set; }
        public int MinLevel { get; set; }
        public TimeSpan TotalTime { get; set; }
        public TimeSpan AverageTime { get; set; }
    }
}
