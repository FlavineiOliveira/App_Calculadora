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
	public partial class AdicionarEstudosView : ContentPage, IMessage
	{
        AdicionarEstudosViewModel adicionarEstudosViewModel;

        public AdicionarEstudosView ()
		{
			InitializeComponent ();

            adicionarEstudosViewModel = new AdicionarEstudosViewModel
            {
                Message = this,
                Navigation = this.Navigation
            };
            BindingContext = adicionarEstudosViewModel;
        }

        private void NomeCurso_Completed(object sender, EventArgs e)
        {
            entryValorInvestimento.Focus();
        }

        private void ValorInvestimento_Completed(object sender, EventArgs e)
        {
            entryPeriodoEstudado.Focus();
        }
    }
}