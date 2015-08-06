using System.Collections.Generic;
using DAL.Model;

namespace DataImporter
{
    public interface IDataImporterClass
    {
        void Import(string data);
    }

    public interface IGameParser
    {
        IEnumerable<Game> Parse(string data);
    }
}
