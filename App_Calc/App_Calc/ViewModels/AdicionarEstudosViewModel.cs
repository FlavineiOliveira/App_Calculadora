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
            calcularServicoViewModel = new CalcularServicoViewModel();

            Entidade.PeriodoEstudado = 1;
        }

        public ICommand IncluirEstudosCommand
        {
            get
            {
                return incluirEstudosCommand ?? (incluirEstudosCommand = new Command(() =>
                {
                    try
                    {
                        if (string.IsNullOrEmpty(Entidade.NomeCurso))
                            Message.DisplayAlert("Erro", "O nome não pode estar vazio", "Ok");

                        else if (ValorInvestimento == 0)
                            Message.DisplayAlert("Erro", "O valor do investimento não pode ser igual à R$0,00", "Ok");

                        else if (Entidade.PeriodoEstudado < 1)
                            Message.DisplayAlert("Erro", "O período não pode ser menor que 1", "Ok");

                        else
                        {
                            Entidade.ValorInvestimento = ValorInvestimento;
                            Entidade.ValorProporcionalServico = ValorInvestimento / Entidade.PeriodoEstudado;

                            calcularServicoViewModel.AdicionarEstudo(Entidade);

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
