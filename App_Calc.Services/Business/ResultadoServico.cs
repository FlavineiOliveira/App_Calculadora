using App_Calc.Domain.Entidade;
using System;
using System.Collections.ObjectModel;

namespace App_Calc.Services.Business
{
    public class ResultadoServico
    {
        public RootResultadoServico CalcularValorTotalProjeto(decimal lucro, ValorServico valorServico, ObservableCollection<Despesa> despesaCollection, ObservableCollection<Custo> custoCollection, ObservableCollection<Estudo> estudoCollection)
        {
            RootResultadoServico rootResultadoServico = new RootResultadoServico
            {
                ValorTotalLucro = lucro
            };

            if(despesaCollection != null)
                rootResultadoServico.ValorTotalDespesa += CalcularValorTotalDespesa(despesaCollection);

            if (custoCollection != null)
                rootResultadoServico.ValorTotalCusto += CalcularValorTotalCustos(custoCollection);

            if (estudoCollection != null)
                rootResultadoServico.ValorTotalEstudo += CalcularValorTotalEstudo(estudoCollection, valorServico.DiasTrabalhados);

            rootResultadoServico.ValorTotalDesconto = (rootResultadoServico.ValorTotalDespesa + rootResultadoServico.ValorTotalCusto + rootResultadoServico.ValorTotalEstudo);

            rootResultadoServico.ValorTotalProjeto += rootResultadoServico.ValorTotalDesconto + rootResultadoServico.ValorTotalLucro;

            rootResultadoServico.HorasTotalTrabalhadas = CalcularHoraTotalTrabalhada(valorServico.HorasTrabalhadas, valorServico.DiasTrabalhados);

            rootResultadoServico.ValorHoraTrabalhada = CalcularValorHora(rootResultadoServico.ValorTotalProjeto, rootResultadoServico.HorasTotalTrabalhadas);

            return rootResultadoServico;
        }

        public int CalcularHoraTotalTrabalhada(int horasTrabalhadas, int diasTrabalhados)
        {
           return diasTrabalhados * horasTrabalhadas;
        }

        public decimal CalcularValorHora(decimal valorTotalProjeto, int horaTotalTrabalhada)
        {
            if (valorTotalProjeto == 0 || horaTotalTrabalhada == 0)
                return 0;

            return valorTotalProjeto / horaTotalTrabalhada;
        }

        public decimal CalcularValorTotalDespesa(ObservableCollection<Despesa> despesas)
        {
            decimal valor = 0;

            foreach (var itemDespesa in despesas)
            {
                valor += itemDespesa.ValorDespesa;
            }

            return valor;
        }

        public decimal CalcularValorTotalCustos(ObservableCollection<Custo> custos)
        {
            decimal valor = 0;

            foreach (var itemDespesa in custos)
            {
                valor += itemDespesa.ValorCusto;
            }

            return valor;
        }

        public decimal CalcularValorTotalEstudo(ObservableCollection<Estudo> estudos, int diasTrabalhados)
        {
            decimal valorEstudos = 0;

            int periodoTrabalhado = Convert.ToInt32(Math.Ceiling((decimal)diasTrabalhados / 30));

            if (periodoTrabalhado == 0)
                periodoTrabalhado = 1;

            foreach (var itemDespesa in estudos)
            {
                itemDespesa.ValorProporcionalServico = (itemDespesa.ValorInvestimento / itemDespesa.PeriodoEstudado) * periodoTrabalhado;
                valorEstudos += itemDespesa.ValorProporcionalServico;
            }

            return valorEstudos;
        }
    }
}
