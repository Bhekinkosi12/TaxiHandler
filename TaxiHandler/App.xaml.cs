using System;
using TaxiHandler.Services;
using TaxiHandler.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiHandler
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
