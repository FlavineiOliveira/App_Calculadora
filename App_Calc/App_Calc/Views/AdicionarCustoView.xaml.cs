using App_Calc.Interfaces;
using App_Calc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace App_Calc.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdicionarCustoView : ContentPage, IMessage
	{
        AdicionarCustosViewModel adicionarCustoViewModel;

		public AdicionarCustoView ()
		{
			InitializeComponent ();

            adicionarCustoViewModel = new AdicionarCustosViewModel
            {
                Message = this,
                Navigation = this.Navigation
            };
            BindingContext = adicionarCustoViewModel;
        }
	}
}