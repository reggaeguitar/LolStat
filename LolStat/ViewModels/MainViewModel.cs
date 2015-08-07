using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DataImporter;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace LolStat.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        // dependencies
        private readonly IDataImporterClass _dataImporter;
        private readonly IDatabaseChecker _databaseChecker;
        private readonly IDatabaseSeeder _databaseSeeder;
        
        // ctor
        public MainViewModel(
            IDataImporterClass dataImporter,
            IDatabaseChecker databaseChecker,
            IDatabaseSeeder databaseSeeder)
        {
            _dataImporter = dataImporter;
            _databaseChecker = databaseChecker;
            _databaseSeeder = databaseSeeder;

            ImportCommand = new RelayCommand(Import);
        }

        // commands
        public ICommand ImportCommand { get; private set; }

        #region bindable properties

        private string _importText;
        public string ImportText
        {
            get { return _importText; }
            set
            {
                if (_importText == value) return;
                _importText = value;
                RaisePropertyChanged(() => ImportText);
            }
        }
        #endregion

        // methods
        private void Import()
        {
            if (!_databaseChecker.HasNonGameData())
            {
                _databaseSeeder.Seed();
            }
            _dataImporter.Import(ImportText);
            MessageBox.Show("Import successful!");
        }
    }
}
