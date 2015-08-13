using DAL.Model;
using DataImporter;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using LolStat.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LolStat.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        // dependencies
        private readonly IDataImporterClass _dataImporter;
        private readonly IDatabaseChecker _databaseChecker;
        private readonly IDatabaseSeeder _databaseSeeder;
        private readonly IDataLoader _dataLoader;
        
        // ctor
        public MainViewModel(
            IDataImporterClass dataImporter,
            IDatabaseChecker databaseChecker,
            IDatabaseSeeder databaseSeeder, IDataLoader dataLoader)
        {
            _dataImporter = dataImporter;
            _databaseChecker = databaseChecker;
            _databaseSeeder = databaseSeeder;
            _dataLoader = dataLoader;

            ImportCommand = new RelayCommand(Import);
            LoadedCommand = new RelayCommand(Loaded);

            Games = new ObservableCollection<Game>();
        }

        // commands
        public ICommand ImportCommand { get; private set; }
        public ICommand LoadedCommand { get; private set; }

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

        private ObservableCollection<Game> _games;
        public ObservableCollection<Game> Games
        {
            get { return _games; }
            set
            {
                if (_games == value) return;
                _games = value;
                RaisePropertyChanged(() => Games);
            }
        }

        private ObservableCollection<ChampInfo> _champInfos;
        public ObservableCollection<ChampInfo> ChampInfos
        {
            get { return _champInfos; }
            set
            {
                if (_champInfos == value) return;
                _champInfos = value;
                RaisePropertyChanged(() => ChampInfos);
            }
        }
        
        #endregion

        // methods
        private void Loaded()
        {
            RefreshAll();
        }

        private void Import()
        {
            if (!_databaseChecker.HasNonGameData())
            {
                _databaseSeeder.Seed();
            }
            _dataImporter.Import(ImportText);
            RefreshAll();
            MessageBox.Show("Import successful!");
        }

        private void RefreshAll()
        {
            Games = new ObservableCollection<Game>(_dataLoader.LoadGames());
            ChampInfos = new ObservableCollection<ChampInfo>(_dataLoader.LoadChampInfos());
        }
    }
}
