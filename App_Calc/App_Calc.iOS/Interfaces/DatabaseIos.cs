using App_Calc.Interfaces;
using App_Calc.iOS.Interfaces;
using SQLite;
using System.IO;

[assembly:Xamarin.Forms.Dependency(typeof(DatabaseIos))]
namespace App_Calc.iOS.Interfaces
{
    public class DatabaseIos : IDatabase
    {
        public SQLiteConnection GetConnection()
        {
            var nomeDB = "calculadora.db";

            var personalFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var LibraryFolder = Path.Combine(personalFolder, "..", "Library");

            var caminho = Path.Combine(LibraryFolder, nomeDB);

            return new SQLiteConnection(caminho);
        }
    }
}