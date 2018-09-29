using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
    public class AdicionarDespesaViewModel : ViewModelBase<Despesa>
    {
        private CalcularServicoViewModel calcularServicoViewModel;

        private ICommand incluirDespesasCommand;

        private decimal valorDespesa;

        public decimal ValorDespesa
        {
            get
            {
                return valorDespesa;
            }
            set
            {
                valorDespesa = value;
                RaisePropertyChanged("ValorDespesa");
            }
        }

        public AdicionarDespesaViewModel()
        {
            Despesa despesa = new Despesa();
            calcularServicoViewModel = new CalcularServicoViewModel();
        }

        public ICommand IncluirDespesasCommand
        {
            get
            {
                return incluirDespesasCommand ?? (incluirDespesasCommand = new Command(() =>
                {
                    try
                    {
                        Entidade.ValorDespesa = ValorDespesa;

                        calcularServicoViewModel.AdicionarDespesa(Entidade);

                        Navigation.PopAsync();
                    }
                    catch (Exception ex)
                    {
                        Message.DisplayAlert("Erro", ex.Message, "Ok");
                    }
                }));
            }
        }
    }
}
