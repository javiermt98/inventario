using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Ordenador")]
    public class Ordenador_M: NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int id_ordenador { get; set; }
        public string tipo { get;set; }
        public string funcion { get; set; }
        public string sistop { get; set; }

        [Ignore]
        private bool _activada { get; set; } = false;

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne]
        public Dispositivo dispositivo { get; set; }

        [Ignore]
        public bool activada { get { return _activada; } set { _activada = value; OnPropertyChanged(); } }


    }
}
