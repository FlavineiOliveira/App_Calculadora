using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace App_Calc.ViewModels
{
    [Preserve(AllMembers = true)]
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
                        if (string.IsNullOrEmpty(Entidade.NomeDespesa))
                            Message.DisplayAlert("Erro", "O nome não pode estar vazio", "Ok");

                        else if (ValorDespesa == 0)
                            Message.DisplayAlert("Erro", "O valor não pode ser igual à R$0,00", "Ok");

                        else
                        {
                            Entidade.ValorDespesa = ValorDespesa;

                            calcularServicoViewModel.AdicionarDespesa(Entidade);

                            Navigation.PopAsync();
                        }
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
