using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Switch")]
    public class Switch_M : Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int id_switch { get; set; }

        public int num_puertos { get; set; }
        public double velocidad { get; set; }
        public bool wifi { get; set; }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }
    }
}
