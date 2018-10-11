using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace App_Calc.ViewModels
{
    [Preserve(AllMembers = true)]
    public class AdicionarCustosViewModel : ViewModelBase<Custo>
    {
        private CalcularServicoViewModel calcularServicoViewModel;

        private ICommand incluirCustoCommand;

        private decimal valorCusto;

        public decimal ValorCusto
        {
            get
            {
                return valorCusto;
            }
            set
            {
                valorCusto = value;
                RaisePropertyChanged("ValorCusto");
            }
        }

        public AdicionarCustosViewModel()
        {
            calcularServicoViewModel = new CalcularServicoViewModel();
        }

        public ICommand IncluirCustoCommand
        {
            get
            {
                return incluirCustoCommand ?? (incluirCustoCommand = new Command ( () => 
                {
                    try
                    {
                        if(string.IsNullOrEmpty(Entidade.NomeCusto))
                            Message.DisplayAlert("Erro", "O nome não pode estar vazio", "Ok");

                        else if(ValorCusto == 0)
                            Message.DisplayAlert("Erro", "O valor não pode ser igual à R$0,00", "Ok");

                        else
                        {
                            Entidade.ValorCusto = ValorCusto;

                            calcularServicoViewModel.AdicionarCusto(Entidade);

                            Navigation.PopAsync();
                        }
                    }
                    catch(Exception ex)
                    {
                        Message.DisplayAlert("Erro", ex.Message, "Ok");
                    }
                }));
            }
        }
    }
}
