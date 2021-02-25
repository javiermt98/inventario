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
    public class DaoMonitores
    {
        private SQLiteAsyncConnection connection;

        public DaoMonitores(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal List<Monitor_M> AllMonitoresAsync()
        {
            if (Provider.auladeldispositivo != null)
            {
                List<Monitor_M> monRelleno = new List<Monitor_M>();
                List<Monitor_M> monitores = this.connection.QueryAsync<Monitor_M>("Select m.* from Monitor m,Dispositivos d where m.Dispositivo = d.id_dispositivo and d.id_aula = " + Provider.auladeldispositivo.Id).Result;
                foreach (Monitor_M m in monitores)
                {
                    Monitor_M mon = new Monitor_M();
                    mon = this.connection.GetWithChildrenAsync<Monitor_M>(m.id_monitor).Result;
                    monRelleno.Add(mon);
                }
                return monRelleno;
            }
            else {
                return this.connection.GetAllWithChildrenAsync<Monitor_M>().Result;
            }
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
                this.connection.UpdateWithChildrenAsync(monitor.dispositivo);
                this.connection.UpdateWithChildrenAsync(monitor);

            }
        }
        public void Borrar(Monitor_M monitor)
        {
            this.connection.DeleteAsync(monitor.dispositivo);
            this.connection.DeleteAsync(monitor);


        }
    }
}
