using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        // ctor
        public MainViewModel(IDataImporterClass dataImporter)
        {
            _dataImporter = dataImporter;

            ImportCommand = new RelayCommand(Import);
        }

        // commands
        public ICommand ImportCommand { get; private set; }

        // bindable properties
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

        // methods
        private void Import()
        {
            _dataImporter.Import(ImportText);
        }
    }
}
