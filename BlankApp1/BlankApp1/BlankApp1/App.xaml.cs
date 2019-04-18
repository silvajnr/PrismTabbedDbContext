using BlankApp1.DataStores;
using BlankApp1.Services;
using BlankApp1.ViewModels;
using BlankApp1.Views;
using DryIoc;
using Prism;
using Prism.Ioc;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlankApp1
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            try
            {
                var navigationResult = await NavigationService.NavigateAsync("NavigationPage/PrismTabbedPage1");
                Debug.WriteLine($"OnInitialized : Navigate Async Success:{navigationResult.Success}");
                if (!navigationResult.Success)
                    Debug.WriteLine($"Exception: {navigationResult.Exception} Exception MessageModel: {navigationResult.Exception.Message} Exception Source: {navigationResult.Exception.Source}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"OnInitialized _navigationService failled ex:{ex.Source} {ex.Message} {ex.InnerException}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Register Navigations
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismTabbedPage1, PrismTabbedPage1ViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage1, PrismContentPage1ViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage2, PrismContentPage2ViewModel>();
            containerRegistry.RegisterForNavigation<PrismContentPage3, PrismContentPage3ViewModel>();
            #endregion

            #region Register DataStores
            var _dbPath = this.Container.Resolve<ISQLite>();
            //containerRegistry.RegisterInstance<IApplicationDbContext>(new ApplicationDbContext(_dbPath));
            //containerRegistry.RegisterSingleton<IApplicationDbContext, ApplicationDbContext>();
            //containerRegistry.Register<IApplicationDbContext, ApplicationDbContext>();
            //containerRegistry.Register<IGenerateDbContext, GenerateDbContext>();
            containerRegistry.RegisterInstance<IGenerateDbContext>(new GenerateDbContext(_dbPath));
            //containerRegistry.RegisterSingleton<IGenerateDbContext, GenerateDbContext>();
            containerRegistry.Register<IMessageDataStore, MessageDataStore>();
            containerRegistry.Register<IChatDataStore, ChatDataStore>();
            #endregion

            #region Register Services
            containerRegistry.Register<IPrismContentPage1Services, PrismContentPage1Services>();
            containerRegistry.Register<IPrismContentPage2Services, PrismContentPage2Services>();
            containerRegistry.Register<IPrismContentPage3Services, PrismContentPage3Services>();
            #endregion
        }

        //protected override void RegisterRequiredTypes(IContainerRegistry containerRegistry)
        //{
        //    base.RegisterRequiredTypes(containerRegistry);
        //    var container = containerRegistry.GetContainer();
        //    //container = container.With(rules => rules.WithUnknownServiceResolvers(req => req.ServiceType != typeof(ApplicationDbContext) ? null : new DelegateFactory(_ => new ApplicationDbContext(_dbPath))));
        //    container.Register<IGenerateDbContext, GenerateDbContext>(setup: Setup.With(allowDisposableTransient: true));
        //}
    }
}
