using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Calc.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IDatabase
    {
        SQLiteConnection GetConnection();
    }
}
