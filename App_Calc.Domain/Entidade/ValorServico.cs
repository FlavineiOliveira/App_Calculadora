using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App_Calc.Domain.Entidade
{
    public class ValorServico
    {
        public decimal LucroDesejado { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int DiasTrabalhados { get; set; }
    }

    public class Despesa
    {
        public string NomeDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
    }

    public class Custo
    {
        public string NomeCusto { get; set; }
        public decimal ValorCusto { get; set; }
    }

    public class Estudo
    {
        public string NomeCurso { get; set; }
        public decimal ValorInvestimento { get; set; }
        public int PeriodoEstudado { get; set; }
        public decimal ValorProporcionalServico { get; set; }
    }

    public class RootCalcularServico
    {
        public ValorServico ValorServico { get; set; }
        public ObservableCollection<Despesa> DespesaCollection { get; set; }
        public ObservableCollection<Custo> CustoCollection { get; set; }
        public ObservableCollection<Estudo> EstudoCollection { get; set; }
    }
}
