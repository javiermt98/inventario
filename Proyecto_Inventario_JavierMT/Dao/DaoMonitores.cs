using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Model;
using SQLiteNetExtensions.Exceptions;

using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace Proyecto_Inventario_JavierMT.Dao
{
    public class DaoMonitores
    {
        private SQLiteAsyncConnection connection;

        public DaoMonitores(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal Task<List<Monitor_M>> AllMonitoresAsync()
        {
            return this.connection.Table<Monitor_M>().ToListAsync();
        }

        public void InsertMonitor(Monitor_M monitor)
        {
            if (monitor.dispositivo.id_dispositivo == 0)
            {
                this.connection.InsertWithChildrenAsync(monitor.dispositivo).Wait();
                this.connection.InsertAsync(monitor).Wait();
                this.connection.UpdateWithChildrenAsync(monitor).Wait();

            }
            else
            {
                this.connection.UpdateWithChildrenAsync(monitor);
            }
        }
    }
}
