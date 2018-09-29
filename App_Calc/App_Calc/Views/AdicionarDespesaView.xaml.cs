using App_Calc.Interfaces;
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
	public partial class AdicionarDespesaView : ContentPage, IMessage
	{
        AdicionarDespesaViewModel adicionarDespesaViewModel;

        public AdicionarDespesaView ()
		{
			InitializeComponent ();

            adicionarDespesaViewModel = new AdicionarDespesaViewModel
            {
                Message = this,
                Navigation = this.Navigation
            };
            BindingContext = adicionarDespesaViewModel;
        }
    }
}