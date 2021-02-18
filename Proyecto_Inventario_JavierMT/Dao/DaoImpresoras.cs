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
    public class DaoImpresoras
    {
        private SQLiteAsyncConnection connection;

        public DaoImpresoras(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal Task<List<Impresora_M>> AllImpresorasAsync()
        {
            return this.connection.Table<Impresora_M>().ToListAsync();
        }

        public void InsertImpresroas(Impresora_M impresora)
        {
            if (impresora.dispositivo.id_dispositivo == 0)
            {
                this.connection.InsertWithChildrenAsync(impresora.dispositivo).Wait();
                this.connection.InsertAsync(impresora).Wait();
                this.connection.UpdateWithChildrenAsync(impresora).Wait();

            }
            else
            {
                this.connection.UpdateWithChildrenAsync(impresora);
            }
        }
        public int Borrar(Impresora_M impresora)
        {
            return this.connection.DeleteAsync(impresora).Result;

        }
    }
}
