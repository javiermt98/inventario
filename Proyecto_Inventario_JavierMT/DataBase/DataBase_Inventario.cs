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
        //public static SQLiteConnection ConectionDatabase = new SQLite.SQLiteConnection(Constants.DatabasePath);

        static DataBase_Inventario() {

            ConectionDatabase.CreateTableAsync<Aula_M>();
            ConectionDatabase.CreateTableAsync<Dispositivo>();
            ConectionDatabase.CreateTableAsync<Impresora_M>();
            ConectionDatabase.CreateTableAsync<Monitor_M>();
            ConectionDatabase.CreateTableAsync<Ordenador_M>();
            ConectionDatabase.CreateTableAsync<Router_M>();
            ConectionDatabase.CreateTableAsync<Switch_M>();

        }
    }
}
