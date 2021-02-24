using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Inventario_JavierMT.Model;
using Proyecto_Inventario_JavierMT.Helpers;
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
        internal List<Ordenador_M> AllOrdenadoresAsync()
        {
            if (Provider.auladeldispositivo != null)
            {

                List<Ordenador_M> ordRelleno = new List<Ordenador_M>();
                List<Ordenador_M> ordenadores = this.connection.QueryAsync<Ordenador_M>("Select o.* from Ordenador o,Dispositivos d where o.Dispositivo = d.id_dispositivo and d.id_aula = " + Provider.auladeldispositivo.Id).Result;
                foreach (Ordenador_M ord in ordenadores)
                {
                    Ordenador_M pc = new Ordenador_M();
                    pc = this.connection.GetWithChildrenAsync<Ordenador_M>(ord.id_ordenador).Result;
                    ordRelleno.Add(pc);
                }
                return ordRelleno;
            }
            else {
                return this.connection.GetAllWithChildrenAsync<Ordenador_M>().Result;
            }
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
                this.connection.UpdateWithChildrenAsync(ordenador.dispositivo);
            }
        }
        public void Borrar(Ordenador_M ordenador)
        {
            this.connection.DeleteAsync(ordenador.dispositivo);
            this.connection.DeleteAsync(ordenador);

        }
    }
}
