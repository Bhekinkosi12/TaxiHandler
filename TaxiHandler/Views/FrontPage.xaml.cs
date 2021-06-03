using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TaxiHandler.Views.Calculator;

namespace TaxiHandler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            InitializeComponent();
        }

        private void Change_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"//{nameof(CalculatorPage)}");
        }
    }
}