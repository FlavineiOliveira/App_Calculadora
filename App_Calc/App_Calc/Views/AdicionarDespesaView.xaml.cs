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
	public partial class AdicionarDespesaView : ContentPage
	{
		public AdicionarDespesaView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}