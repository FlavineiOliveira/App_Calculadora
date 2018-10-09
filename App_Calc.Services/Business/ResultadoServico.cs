using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App_Calc.Services.Business
{
    public class ResultadoServico
    {
        public RootResultadoServico CalcularValorTotalProjeto(decimal lucro, ValorServico valorServico, ObservableCollection<Despesa> despesaCollection, ObservableCollection<Custo> custoCollection, ObservableCollection<Estudo> estudoCollection)
        {
            RootResultadoServico rootResultadoServico = new RootResultadoServico();

            rootResultadoServico.ValorTotalProjeto = lucro;

            rootResultadoServico.ValorTotalProjeto += CalcularValorTotalDespesa(despesaCollection);
            rootResultadoServico.ValorTotalProjeto += CalcularValorTotalCustos(custoCollection);
            rootResultadoServico.ValorTotalProjeto += CalcularValorTotalEstudo(estudoCollection, valorServico.DiasTrabalhados);

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

            decimal mesesTrabalhados = (diasTrabalhados / 30);

            int periodoTrabalhado = Convert.ToInt32(Math.Round(mesesTrabalhados));

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
