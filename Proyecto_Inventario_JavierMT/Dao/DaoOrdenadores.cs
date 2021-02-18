﻿using System;
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
            if (ordenador.dispositivo.id_dispositivo == 0)
            {
                this.connection.InsertWithChildrenAsync(ordenador.dispositivo).Wait();
                this.connection.InsertAsync(ordenador).Wait();
                this.connection.UpdateWithChildrenAsync(ordenador).Wait();

            }
            else
            {
                this.connection.UpdateWithChildrenAsync(ordenador);
            }
        }
        public int Borrar(Ordenador_M ordenador)
        {
            return this.connection.DeleteAsync(ordenador).Result;

        }
    }
}
