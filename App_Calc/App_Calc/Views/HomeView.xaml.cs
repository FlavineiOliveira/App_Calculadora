using App_Calc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Calc.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
        CalcularServicoViewModel calcularServicoViewModel;

        HomeViewModel homeViewModel;

        public HomeView ()
		{
			InitializeComponent ();

            calcularServicoViewModel = new CalcularServicoViewModel();

            homeViewModel = new HomeViewModel();
            BindingContext = homeViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            calcularServicoViewModel.ReiniciarListas();

            Navigation.PushAsync(new CalcularServicoView());
        }
    }
}