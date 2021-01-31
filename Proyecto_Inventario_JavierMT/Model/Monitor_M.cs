using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Monitor")]
    public class Monitor_M : Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int id_monitor { get; set; }
        public double pulgadas { get; set; }
        public string marca { get; set; }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }
    }
}
