using System;
using System.Collections.Generic;
using TaxiHandler.ViewModels;
using TaxiHandler.Views;
using Xamarin.Forms;

namespace TaxiHandler
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
