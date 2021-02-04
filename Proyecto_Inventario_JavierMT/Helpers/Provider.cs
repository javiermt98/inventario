using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Dao;
using Proyecto_Inventario_JavierMT.DataBase;

namespace Proyecto_Inventario_JavierMT.Helpers
{
    public class Provider
    {

        private static DaoAulas _daoAulas;

        public static DaoAulas daoAulas
        {
            get
            {
                if (_daoAulas == null) _daoAulas = new DaoAulas(DataBase_Inventario.ConectionDatabase);
                return _daoAulas;
            }
        }

        private static DaoOrdenadores _daoOrdenadores;

        public static DaoOrdenadores daoOrdenadores
        {
            get
            {
                if (_daoOrdenadores == null) _daoOrdenadores = new DaoOrdenadores(DataBase_Inventario.ConectionDatabase);
                return _daoOrdenadores;
            }
        }
    }
}
