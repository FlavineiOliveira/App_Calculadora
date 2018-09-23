using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
    public class CalcularServicoViewModel : ViewModelBase<RootCalcularServico>
    {
        private Despesa adicionarDespesa;
        private Custo adicionarCusto;
        private Estudo adicionarEstudo;

        private ValorServico teste;

        public ValorServico Teste
        {
            get
            {
                return teste;
            }
            set
            {
                teste = value;
                RaisePropertyChanged("Teste");
            }
        }

        //Por enquanto temporario
        private decimal lucroDesejado;
        private decimal valorDespesa;
        private decimal valorCusto;
        private decimal valorInvestimento;

        private ICommand adicionarDespesaCommand;

        public decimal LucroDesejado
        {
            get
            {
                return lucroDesejado;
            }
            set
            {
                lucroDesejado = value;
                RaisePropertyChanged("LucroDesejado");
            }
        }

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

        public Despesa AdicionarDespesa
        {
            get
            {
                return adicionarDespesa;
            }
            set
            {
                adicionarDespesa = value;
                RaisePropertyChanged("AdicionarDespesa");
            }
        }

        public Custo AdicionarCusto
        {
            get
            {
                return adicionarCusto;
            }
            set
            {
                adicionarCusto = value;
                RaisePropertyChanged("AdicionarCusto");
            }
        }

        public Estudo AdicionarEstudo
        {
            get
            {
                return adicionarEstudo;
            }
            set
            {
                adicionarEstudo = value;
                RaisePropertyChanged("AdicionarEstudo");
            }
        }

        public CalcularServicoViewModel()
        {
            Teste = new ValorServico();
            AdicionarDespesa = new Despesa();
        }

        public ICommand AdicionarDespesaCommand
        {
            get
            {
                return adicionarDespesaCommand ?? (adicionarDespesaCommand = new Command(() => 
                {
                    Entidade.DespesaCollection.Add(new Despesa { NomeDespesa = AdicionarDespesa.NomeDespesa, ValorDespesa = ValorDespesa });

                    Message.DisplayAlert("Parabéns", string.Format("Despesa {0} adicionado na lista.", AdicionarDespesa.NomeDespesa), "Ok");

                }));
            }
        }

    }
}
