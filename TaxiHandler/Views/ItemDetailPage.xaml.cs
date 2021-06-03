using System.ComponentModel;
using TaxiHandler.ViewModels;
using Xamarin.Forms;

namespace TaxiHandler.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}