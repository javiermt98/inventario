using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;
using Proyecto_Inventario_JavierMT.Helpers;

namespace Proyecto_Inventario_JavierMT.Model
{
    [Table("Impresora")]
    public class Impresora_M : NotifyPropertyBase
    {
        [PrimaryKey, AutoIncrement]
        public int id_impresora { get; set; }
        public string tipo { get; set; }
        public bool escaner { get; set; }
        public bool color { get; set; }
        private bool _activada { get; set; } = false;
        [Ignore]
        public bool activada { get { return _activada; } set { _activada = value; OnPropertyChanged(); } }

        [ForeignKey(typeof(Dispositivo))]
        public int Dispositivo { get; set; }
        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Dispositivo dispositivo { get; set; }

    }
}
