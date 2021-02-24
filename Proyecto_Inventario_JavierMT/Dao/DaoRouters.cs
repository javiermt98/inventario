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
    public class DaoRouters
    {
        private SQLiteAsyncConnection connection;

        public DaoRouters(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal List<Router_M> AllRoutersAsync()
        {
            if (Provider.auladeldispositivo != null)
            {

                List<Router_M> routRelleno = new List<Router_M>();
                List<Router_M> routers = this.connection.QueryAsync<Router_M>("Select r.* from Router r,Dispositivos d where r.Dispositivo = d.id_dispositivo and d.id_aula = " + Provider.auladeldispositivo.Id).Result;
                foreach (Router_M r in routers)
                {
                    Router_M rout = new Router_M();
                    rout = this.connection.GetWithChildrenAsync<Router_M>(r.id_router).Result;
                    routRelleno.Add(rout);
                }
                return routRelleno;
            }
            return this.connection.GetAllWithChildrenAsync<Router_M>().Result;

        }

        public void InsertRouters(Router_M router)
        {
            if (router.dispositivo.id_dispositivo == 0)
            {
                
                this.connection.InsertWithChildrenAsync(router.dispositivo).Wait();
                this.connection.InsertAsync(router).Wait();
                this.connection.UpdateWithChildrenAsync(router).Wait();

            }
            else
            {
                this.connection.UpdateWithChildrenAsync(router.dispositivo);
            }
        }
        public void Borrar(Router_M router)
        {
             this.connection.DeleteAsync(router.dispositivo);
             this.connection.DeleteAsync(router);

        }
    }
}
