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

        public HomeView ()
		{
			InitializeComponent ();

            calcularServicoViewModel = new CalcularServicoViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            calcularServicoViewModel.ReiniciarListas();

            Navigation.PushAsync(new CalcularServicoView());
        }
    }
}