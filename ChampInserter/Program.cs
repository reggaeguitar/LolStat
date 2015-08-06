using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace ChampInserter
{
    class Program
    {
        static void Main()
        {
            var lines = File.ReadAllLines("champs.txt")
                .Where(x => x.Trim() != "")
                .Select(x => x.Trim())
                .ToArray();
            using (var ctx = new LolStatModel())
            {
                foreach (var line in lines)
                {
                    ctx.Champions.Add(new Champion {Name = line});
                }
                ctx.SaveChanges();
            }
        }
    }
}
