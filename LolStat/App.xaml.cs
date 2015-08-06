using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DAL;
using DataImporter;
using LolStat.ViewModels;

namespace LolStat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            _container = new WindsorContainer();

            // auto register classes in LolStat dll
            _container.Register(Classes.FromAssemblyContaining<MainViewModel>()
                .IncludeNonPublicTypes()
                .InNamespace("LolStat", includeSubnamespaces: true)
                .WithService.DefaultInterfaces());

            // auto register classes in DataImporter dll
            _container.Register(Classes.FromAssemblyContaining<DataImporterClass>()
                .IncludeNonPublicTypes()
                .InNamespace("DataImporter", includeSubnamespaces: true)
                .WithService.DefaultInterfaces());

            // auto register classes in DataAccessLayer (DAL) dll
            _container.Register(Classes.FromAssemblyContaining<ContextFactory>()
                .IncludeNonPublicTypes()
                .InNamespace("DAL", includeSubnamespaces: true)
                .WithService.DefaultInterfaces());

            var mainWindow = _container.Resolve<IMainWindow>();
            mainWindow.Show();
        }
    }
}
