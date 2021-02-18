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
    public class DaoRouters
    {
        private SQLiteAsyncConnection connection;

        public DaoRouters(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }
        internal Task<List<Router_M>> AllRoutersAsync()
        {
            return this.connection.Table<Router_M>().ToListAsync();
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
                this.connection.UpdateWithChildrenAsync(router);
            }
        }
        public int Borrar(Router_M router)
        {
            return this.connection.DeleteAsync(router).Result;

        }
    }
}
