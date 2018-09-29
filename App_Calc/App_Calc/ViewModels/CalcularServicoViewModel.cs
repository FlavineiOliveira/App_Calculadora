using App_Calc.Domain.Entidade;
using App_Calc.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
    public class CalcularServicoViewModel : ViewModelBase<RootCalcularServico>
    {
        //Por enquanto temporario
        private decimal lucroDesejado;

        private static ObservableCollection<Despesa> listaDespesa;
        private static ObservableCollection<Custo> listaCusto;
        private static ObservableCollection<Estudo> listaEstudo;

        public ObservableCollection<Despesa> ListaDespesa
        {
            get
            {
                return listaDespesa;
            }
            set
            {
                listaDespesa = value;
                RaisePropertyChanged("ListaDespesa");
            }
        }

        public ObservableCollection<Custo> ListaCusto
        {
            get
            {
                return listaCusto;
            }
            set
            {
                listaCusto = value;
                RaisePropertyChanged("ListaCusto");
            }
        }

        public ObservableCollection<Estudo> ListaEstudo
        {
            get
            {
                return listaEstudo;
            }
            set
            {
                listaEstudo = value;
                RaisePropertyChanged("ListaEstudo");
            }
        }

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

        public CalcularServicoViewModel(Custo custo)
        {
            AdicionarCusto(custo);
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            if (ListaDespesa == null)
                ListaDespesa = new ObservableCollection<Despesa>();

            if (despesa.NomeDespesa != null)
                ListaDespesa.Add(new Despesa { NomeDespesa = despesa.NomeDespesa, ValorDespesa = despesa.ValorDespesa });
        }

        public void AdicionarCusto(Custo custo)
        {
            if (ListaCusto == null)
                ListaCusto = new ObservableCollection<Custo>();

            if (custo.NomeCusto != null)
                ListaCusto.Add(new Custo { NomeCusto = custo.NomeCusto, ValorCusto = custo.ValorCusto });
        }

        public void AdicionarEstudo(Estudo estudo)
        {
            if (ListaEstudo == null)
                ListaEstudo = new ObservableCollection<Estudo>();

            if (estudo.NomeCurso != null)
                ListaEstudo.Add(new Estudo { NomeCurso = estudo.NomeCurso, ValorInvestimento = estudo.ValorInvestimento, PeriodoEstudado = estudo.PeriodoEstudado, ValorProporcionalServico = 0 });
        }

    }
}
