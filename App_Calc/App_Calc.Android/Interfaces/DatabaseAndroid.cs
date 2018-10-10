using App_Calc.Droid.Interfaces;
using App_Calc.Interfaces;
using SQLite;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(DatabaseAndroid))]
namespace App_Calc.Droid.Interfaces
{
    public class DatabaseAndroid : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = "calculadora.db";

            var caminho = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), nomeDB);

            return new SQLiteConnection(caminho);
        }
    }
}