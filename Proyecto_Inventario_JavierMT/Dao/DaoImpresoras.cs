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
    public class DaoImpresoras
    {
        private SQLiteAsyncConnection connection;

        public DaoImpresoras(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal List<Impresora_M> AllImpresorasAsync()
        {
            if (Provider.auladeldispositivo != null)
            {
                List<Impresora_M> impRelleno = new List<Impresora_M>();
                List<Impresora_M> impresoras = this.connection.QueryAsync<Impresora_M>("Select i.* from Impresora i,Dispositivos d where i.Dispositivo = d.id_dispositivo and d.id_aula = " + Provider.auladeldispositivo.Id).Result;
                foreach (Impresora_M m in impresoras)
                {
                    Impresora_M mon = new Impresora_M();
                    mon = this.connection.GetWithChildrenAsync<Impresora_M>(m.id_impresora).Result;
                    impRelleno.Add(mon);
                }
                return impRelleno;
            }
            else {
                return this.connection.GetAllWithChildrenAsync<Impresora_M>().Result;
            }


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
                this.connection.UpdateWithChildrenAsync(impresora.dispositivo);
            }
        }
        public void Borrar(Impresora_M impresora)
        {
            this.connection.DeleteAsync(impresora.dispositivo);
            this.connection.DeleteAsync(impresora);


        }
    }
}
