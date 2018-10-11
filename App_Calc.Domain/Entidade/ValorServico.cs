using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App_Calc.Domain.Entidade
{
    [Preserve(AllMembers = true)]
    public class ValorServico
    {
        public decimal LucroDesejado { get; set; }
        public int HorasTrabalhadas { get; set; }
        public int DiasTrabalhados { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Despesa
    {
        public string NomeDespesa { get; set; }
        public decimal ValorDespesa { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Custo
    {
        public string NomeCusto { get; set; }
        public decimal ValorCusto { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class Estudo
    {
        public string NomeCurso { get; set; }
        public decimal ValorInvestimento { get; set; }
        public int PeriodoEstudado { get; set; }
        public decimal ValorProporcionalServico { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class RootCalcularServico
    {
        public ValorServico ValorServico { get; set; }
        public Despesa Despesa { get; set; }
        public Custo Custo { get; set; }
        public Estudo Estudo { get; set; }
    }

    [Preserve(AllMembers = true)]
    public class RootResultadoServico
    {
        public decimal ValorTotalProjeto { get; set; }
        public decimal ValorTotalLucro { get; set; }
        public int HorasTotalTrabalhadas { get; set; }
        public decimal ValorHoraTrabalhada { get; set; }
        public decimal ValorTotalDesconto { get; set; }
        public decimal ValorTotalDespesa { get; set; }
        public decimal ValorTotalCusto { get; set; }
        public decimal ValorTotalEstudo { get; set; }
    }

    [Preserve(AllMembers = true)]
    [Table("RootServico")]
    public class RootServico
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        string Identificador { get; set; }
        public ValorServico ValorServico { get; set; }
        public ObservableCollection<Despesa> ListaDespesa { get; set; }
        public ObservableCollection<Custo> ListaCusto { get; set; }
        public ObservableCollection<Estudo> ListaEstudo { get; set; }
        public RootResultadoServico RootResultadoServico { get; set; } 
    }

    [Preserve(AllMembers = true)]
    [Table("Teste")]
    public class Teste
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        string Identificador { get; set; }
        //public ValorServico ValorServico { get; set; }
    }
}
