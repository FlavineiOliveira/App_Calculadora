﻿using App_Calc.Database;
using App_Calc.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App_Calc.ViewModels
{
    public class HomeViewModel : ViewModelBase<ValorServico>
    {
        private ObservableCollection<RootServico> rootServicoCollection;

        public ObservableCollection<RootServico> RootServicoCollection
        {
            get
            {
                return rootServicoCollection;
            }
            set
            {
                rootServicoCollection = value;
                RaisePropertyChanged("RootServicoCollection");
            }
        }

        public HomeViewModel()
        {
            var teste = new ObservableCollection<Teste>(new ServicosDatabase().GetServicos());
        }
    }
}
