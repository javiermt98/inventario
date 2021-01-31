using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Ordenador")]
    public class Ordenador_M: Dispositivo
    {
        [ForeignKey(typeof(Dispositivo))]
        public int id_ordenador { get; set; }
        public string tipo { get;set; }
        public string funcion { get; set; }
        public string sistop { get; set; }

        public Ordenador_M() { }
        public Ordenador_M(string tipo, string funcion, string sistop) {

            this.tipo = tipo;
            this.funcion = funcion;
            this.sistop = sistop;
        }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }


    }
}
