using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
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
                        Entidade.ValorCusto = ValorCusto;

                        calcularServicoViewModel.AdicionarCusto(Entidade);    
                        
                        Navigation.PopAsync();
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
