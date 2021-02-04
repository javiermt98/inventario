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
    public class DaoOrdenadores
    {
        private SQLiteAsyncConnection connection;

        public DaoOrdenadores(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal Task<List<Ordenador_M>> AllOrdenadoresAsync()
        {
            return this.connection.Table<Ordenador_M>().ToListAsync();
        }

        public void InsertOrdenadores(Ordenador_M ordenador)
        {
            if (ordenador.disp.id_dispositivo == 0)
            {
                this.connection.InsertWithChildrenAsync(ordenador.disp);
            }
            else
            {
                this.connection.UpdateWithChildrenAsync(ordenador.disp);
            }
        }
    }
}
