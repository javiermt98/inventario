using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Router")]
    public class Router_M : Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int id_router { get; set; }


        private int num_puertos { get; set; }
        private double velocidad { get; set; }
        private bool wifi { get; set; }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }

    }
}
