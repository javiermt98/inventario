using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Ordenador")]
    public class Ordenador_M: Dispositivo
    {
        [ForeignKey(typeof(Dispositivo))]
        public int id_ordenador { get; set; }

        private string tipo { get;set; }
        private string funcion { get; set; }
        private string sistop { get; set; }
        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }

    }
}
