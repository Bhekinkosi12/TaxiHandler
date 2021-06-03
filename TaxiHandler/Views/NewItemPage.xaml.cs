using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaxiHandler.Models;
using TaxiHandler.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiHandler.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}