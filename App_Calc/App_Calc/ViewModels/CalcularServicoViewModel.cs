using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Calc.ViewModels
{
    public class CalcularServicoViewModel : ViewModelBase<RootCalcularServico>
    {
        private Despesa adicionarDespesa;
        private Custo adicionarCusto;
        private Estudo adicionarEstudo;

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
           
        }
    }
}
