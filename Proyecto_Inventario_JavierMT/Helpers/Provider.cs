using System;
using System.Collections.Generic;
using System.Text;
using Proyecto_Inventario_JavierMT.Dao;
using Proyecto_Inventario_JavierMT.DataBase;
using Proyecto_Inventario_JavierMT.Model;

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
        private static DaoImpresoras _daoImpresoras;

        public static DaoImpresoras daoImpresoras
        {
            get
            {
                if (_daoImpresoras == null) _daoImpresoras = new DaoImpresoras(DataBase_Inventario.ConectionDatabase);
                return _daoImpresoras;
            }
        }

        private static DaoMonitores _daoMonitores;

        public static DaoMonitores daoMonitores
        {
            get
            {
                if (_daoMonitores == null) _daoMonitores = new DaoMonitores(DataBase_Inventario.ConectionDatabase);
                return _daoMonitores;
            }
        }

        private static DaoRouters _daoRouters;

        public static DaoRouters daoRouters
        {
            get
            {
                if (_daoRouters == null) _daoRouters = new DaoRouters(DataBase_Inventario.ConectionDatabase);
                return _daoRouters;
            }
        }

        public static List<String> listatipos { get; set; } = new List<String> { "Sobremesa", "Portatil" };
        public static List<String> listafuncion { get; set; } = new List<String> { "Servidor de Aula", "Cliente" };
        public static List<String> listasistop { get; set; } = new List<String> 
        {
            "Windows Activado",
            "Windows No Activado",
            "Windows Lliurex",
            "Windows Linux",
            "DUAL (Windows Activado / Lliurex)",
            "DUAL (Windows No Activado / Lliurex)",
            "DUAL (Windows Activado / Linux)",
            "DUAL (Windows No Activado / Linux)",
            "DUAL (Linux / Lliurex)"
        };

        public static Aula_M auladeldispositivo { get; set; }

        public static List<String> listatiposimpresora { get; set; } = new List<String> { "Laser", "Tinta" };

    }
}
