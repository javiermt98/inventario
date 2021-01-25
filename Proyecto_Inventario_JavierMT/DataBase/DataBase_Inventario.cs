using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Helpers;
using Proyecto_Inventario_JavierMT.Model;

namespace Proyecto_Inventario_JavierMT.DataBase
{
    public class DataBase_Inventario
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        public static SQLiteAsyncConnection ConectionDatabase => lazyInitializer.Value;

        static DataBase_Inventario() {

            ConectionDatabase.CreateTableAsync<Aula_M>();
        }
    }
}
