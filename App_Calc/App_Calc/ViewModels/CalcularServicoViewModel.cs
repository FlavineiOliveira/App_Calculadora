using App_Calc.Database;
using App_Calc.Domain;
using App_Calc.Domain.Entidade;
using App_Calc.Services.Business;
using App_Calc.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Calc.ViewModels
{
    public class CalcularServicoViewModel : ViewModelBase<ValorServico>
    {
        private ICommand salvarServicoCommand;

        private decimal lucroDesejado;

        private ResultadoServico resultadoServico;

        public static ObservableCollection<Despesa> ReceberDespesaCollection;
        public static ObservableCollection<Custo> ReceberCustoCollection;
        public static ObservableCollection<Estudo> ReceberEstudoCollection;

        private ObservableCollection<Despesa> listaDespesa;
        private ObservableCollection<Custo> listaCusto;
        private ObservableCollection<Estudo> listaEstudo;
        private RootResultadoServico rootResultadoServico;

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

        public RootResultadoServico RootResultadoServico
        {
            get
            {
                return rootResultadoServico;
            }
            set
            {
                rootResultadoServico = value;
                RaisePropertyChanged("RootResultadoServico");
            }
        }

        public CalcularServicoViewModel()
        {
            resultadoServico = new ResultadoServico();
        }

        public ICommand SalvarServicoCommand
        {
            get
            {
                return salvarServicoCommand ?? (salvarServicoCommand = new Command(() =>
                {
                    RootServico rootServico = new RootServico
                    {
                        ValorServico = new ValorServico { LucroDesejado = LucroDesejado, DiasTrabalhados = Entidade.DiasTrabalhados, HorasTrabalhadas = Entidade.HorasTrabalhadas },
                        ListaCusto = ListaCusto,
                        ListaDespesa = ListaDespesa,
                        ListaEstudo = ListaEstudo,
                        RootResultadoServico = RootResultadoServico
                    };

                    var teste = new ServicosDatabase().SalvarServico(rootServico);

                    Message.DisplayAlert("", "Serviço salvo.", "Ok");

                }));
            }
        }

        public void ReiniciarListas()
        {
            ReceberDespesaCollection = new ObservableCollection<Despesa>();
            ReceberCustoCollection = new ObservableCollection<Custo>();
            ReceberEstudoCollection = new ObservableCollection<Estudo>();
        }

        public void AdicionarDespesa(Despesa despesa)
        {
            if (ReceberDespesaCollection == null)
                ReceberDespesaCollection = new ObservableCollection<Despesa>();

            if (despesa.NomeDespesa != null)
                ReceberDespesaCollection.Add(new Despesa { NomeDespesa = despesa.NomeDespesa, ValorDespesa = despesa.ValorDespesa });
        }

        public void AdicionarCusto(Custo custo)
        {
            if (ReceberCustoCollection == null)
                ReceberCustoCollection = new ObservableCollection<Custo>();

            if (custo.NomeCusto != null)
                ReceberCustoCollection.Add(new Custo { NomeCusto = custo.NomeCusto, ValorCusto = custo.ValorCusto });
        }

        public void AdicionarEstudo(Estudo estudo)
        {
            if (ReceberEstudoCollection == null)
                ReceberEstudoCollection = new ObservableCollection<Estudo>();

            if (estudo.NomeCurso != null)
                ReceberEstudoCollection.Add(new Estudo { NomeCurso = estudo.NomeCurso, ValorInvestimento = estudo.ValorInvestimento, PeriodoEstudado = estudo.PeriodoEstudado, ValorProporcionalServico = estudo.ValorProporcionalServico });
        }

        public void AtualizarCollections()
        {
            ListaDespesa = ReceberDespesaCollection;
            ListaCusto = ReceberCustoCollection;
            ListaEstudo = ReceberEstudoCollection;
        }

        public void AtualizarResultados()
        {
            AtualizarCollections();

            rootResultadoServico = new RootResultadoServico();

            //if (LucroDesejado != 0)
           // {
                rootResultadoServico = resultadoServico.CalcularValorTotalProjeto(LucroDesejado, Entidade, ListaDespesa, ListaCusto, ListaEstudo);
           // }

            RaisePropertyChanged("RootResultadoServico");
        }
    }
}
