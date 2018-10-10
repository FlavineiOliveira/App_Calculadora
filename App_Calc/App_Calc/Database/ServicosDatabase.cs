using App_Calc.Domain.Entidade;
using App_Calc.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App_Calc.Database
{
    public class ServicosDatabase
    {
        private SQLiteConnection database;

        public ServicosDatabase()
        {
            try
            {
                database = DependencyService.Get<IDatabase>().GetConnection();
                database.CreateTable<Teste>();


            }
            catch(SQLiteException ex)
            {
                throw ex;
            }

        }

        public List<Teste> GetServicos()
        {
            return database.Table<Teste>().ToList();
        }

        public int SalvarServico(RootServico servico)
        {
            return database.Insert(servico);
        }

        public int AtualizarServico(RootServico servico)
        {
            return database.Update(servico);
        }

        public int DeletarServico(RootServico servico)
        {
            return database.Delete(servico);
        }


    }
}
