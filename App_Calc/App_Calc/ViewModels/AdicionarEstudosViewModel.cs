using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
    public class AdicionarEstudosViewModel : ViewModelBase<Estudo>
    {
        private CalcularServicoViewModel calcularServicoViewModel;

        private ICommand incluirEstudosCommand;

        private decimal valorInvestimento;

        public decimal ValorInvestimento
        {
            get
            {
                return valorInvestimento;
            }
            set
            {
                valorInvestimento = value;
                RaisePropertyChanged("ValorInvestimento");
            }
        }

        public AdicionarEstudosViewModel()
        {
            Estudo estudo = new Estudo();
            calcularServicoViewModel = new CalcularServicoViewModel();
        }

        public ICommand IncluirEstudosCommand
        {
            get
            {
                return incluirEstudosCommand ?? (incluirEstudosCommand = new Command(() =>
                {
                    try
                    {
                        Entidade.ValorInvestimento = ValorInvestimento;
                        Entidade.ValorProporcionalServico = ValorInvestimento / Entidade.PeriodoEstudado;

                        calcularServicoViewModel.AdicionarEstudo(Entidade);

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
