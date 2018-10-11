using App_Calc.Domain.Entidade;
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
	public partial class CalcularServicoView : TabbedPage, IMessage
	{
        CalcularServicoViewModel calcularServicoViewModel;

        public CalcularServicoView ()
		{
			InitializeComponent ();

            calcularServicoViewModel = new CalcularServicoViewModel()
            {
                Message = this,
                Navigation = this.Navigation
            };
            BindingContext = calcularServicoViewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            calcularServicoViewModel.AtualizarCollections();
        }

        private async void AdicionarDespesa_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdicionarDespesaView());
        }

        private async void AdicionarCusto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdicionarCustoView());
        }

        private async void AdicionarEstudo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdicionarEstudosView());
        }

        private void Resultados_Appearing(object sender, EventArgs e)
        {
            calcularServicoViewModel.AtualizarResultados();
        }

        private void MenuItemDespesa_Clicked(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Despesa;
            calcularServicoViewModel.ListaDespesa.Remove(item);
        }

        private void MenuItemCusto_Clicked(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Custo;
            calcularServicoViewModel.ListaCusto.Remove(item);
        }

        private void MenuItemEstudo_Clicked(object sender, EventArgs e)
        {
            var item = ((MenuItem)sender).CommandParameter as Estudo;
            calcularServicoViewModel.ListaEstudo.Remove(item);
        }
    }
}