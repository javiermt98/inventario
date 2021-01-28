using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Model;
using SQLiteNetExtensions.Exceptions;

using SQLite;

namespace Proyecto_Inventario_JavierMT.Dao
{
    public class DaoAulas
    {
        private SQLiteAsyncConnection connection;

        public DaoAulas(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        public Task<List<Aula_M>> AllAulasAsync() {

            return this.connection.Table<Aula_M>().ToListAsync();
        }

        public int Insert(Aula_M aula)
        {
            if (aula.Id == 0)
            {
                return this.connection.InsertAsync(aula).Result;
            }
            else
            {
                return this.connection.UpdateAsync(aula).Result;
            }
        }

        internal Task<List<Aula_M>> DispositivosPorClase(int id)
        {
            throw new NotImplementedException();
        }

        public int Borrar(Aula_M aula)
        {
            return this.connection.DeleteAsync(aula).Result;
        }


    }
    }
